import React, { useState } from "react";
import Select from "react-select";
import {
  Button,
  Col,
  Form,
  FormFeedback,
  Input,
  Label,
  Modal,
  ModalBody,
  ModalHeader,
  Row,
  Spinner,
} from "reactstrap";
import { CommentTypes } from "../../constants/Common";
import Rating from "react-rating";
import * as Yup from "yup";
import { useFormik } from "formik";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import PreviewMultiImage from "../../Admin/components/Dropzone/PreviewMultiImage";
import { Error } from "../../components/Notification/Error";

const AddComment = ({ isOpen, toggle, newComment, userId, productId }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
    const [photos, setPhotos] = useState(null);
    const [commentType, setCommentType] = useState(null);

  const validation = useFormik({
    initialValues: {
      rating: 0,
      pluses: "",
      minuses: "",
      text: "",
      commentType: "",
    },
    validationSchema: Yup.object({
      rating: Yup.number()
        .min(1)
        .max(5)
        .required("Заполните обязательное поле"),
    }),
    onSubmit: (values) => {

      setIsLoading(true);
      const data = new FormData();
      data.append("text", values.text);
      data.append("rating", values.rating);
      data.append("pluses", values.pluses);
      data.append("minuses", values.minuses);
      data.append("commentType", commentType);
      data.append("userId", userId);
      data.append("productId", productId);

      if (photos) {
        photos.forEach((file, i) => data.append(`files[${i}]`, file));
        data.append("photos", photos);
        data.append("type", "comments");
      }

        fetchWrapper
          .post("api/review/newreview", data, false)
          .then((response) => {
            setIsLoading(false);
            setError(null);
            validation.resetForm();
            toggle();
            newComment(response);
          })
          .catch((error) => {
            setIsLoading(false);
            setError(error);
          });
    },
  });

  function handleUpdateFiles(files) {
    setPhotos(files.map((file) => file.file));
  }

  const handleCommentTypeChange = (e) => {
    setCommentType(e.value);
  };

  return (
    <React.Fragment>
    {error ? <Error message={error} /> : null}
      <Modal isOpen={isOpen} toggle={toggle} size={"lg"}>
        <ModalHeader
          className={"p-3 bg-soft-white border-bottom-dashed"}
          style={{ borderBottom: "1px" }}
          toggle={toggle}
        >
          Добавить новый отзыв
        </ModalHeader>
        <ModalBody>
          <Form
            onSubmit={(e) => {
              e.preventDefault();
              validation.handleSubmit(e);
              return false;
            }}
          >
            <Row>
              <Col lg={12} className={"mb-1"}>
                <Label className={"form-label"} htmlFor={"commentType"}>
                  Я использую товар
                </Label>
                <Select
                  options={CommentTypes}
                  defaultValue={CommentTypes[0] || []}
                  id={"commentType"}
                  onChange={handleCommentTypeChange}
                />
              </Col>
              <Col lg={6} className={"mb-1"}>
                <Label className={"form-label"} htmlFor={"rating"}>
                  Общая оценка
                </Label>
                <Input
                  className={"form-control"}
                  type={"number"}
                  min={1}
                  max={5}
                  id={"rating"}
                  name={"rating"}
                  placeholder={"Общая оцена"}
                  onChange={validation.handleChange}
                  onBlur={validation.handleBlur}
                  defaultValue={""}
                  invalid={
                    !!(validation.touched.rating && validation.errors.rating)
                  }
                />
                {validation.touched.rating && validation.errors.rating ? (
                  <FormFeedback type="invalid">
                    {validation.errors.rating}
                  </FormFeedback>
                ) : null}
              </Col>
              <Col
                lg={6}
                className={"d-flex justify-content-start align-items-center"}
              >
                <Rating
                  initialRating={validation.values.rating}
                  className={"fs-24"}
                  emptySymbol={"mdi mdi-star-outline text-muted"}
                  fullSymbol={"mdi mdi-star text-warning"}
                  readonly={true}
                />
              </Col>
              <Col lg={12} className={"mb-1"}>
                <Label className={"form-label"} htmlFor={"pluses"}>
                  Достоинства
                </Label>
                <textarea
                  className={"form-control"}
                  type={"text"}
                  id={"pluses"}
                  name={"pluses"}
                  placeholder={"Достоинства"}
                  onChange={validation.handleChange}
                  onBlur={validation.handleBlur}
                />
              </Col>
              <Col lg={12} className={"mb-1"}>
                <Label className={"form-label"} htmlFor={"minuses"}>
                  Недостатки
                </Label>
                <textarea
                  className={"form-control"}
                  type={"text"}
                  id={"minuses"}
                  name={"minuses"}
                  placeholder={"Достоинства"}
                  onChange={validation.handleChange}
                  onBlur={validation.handleBlur}
                />
              </Col>
              <Col lg={12} className={"mb-2"}>
                <Label className={"form-label"} htmlFor={"text"}>
                  Коментарий
                </Label>
                <textarea
                  className={"form-control"}
                  type={"text"}
                  id={"text"}
                  name={"text"}
                  placeholder={"Коментарий"}
                  onChange={validation.handleChange}
                  onBlur={validation.handleBlur}
                />
              </Col>
              <Col lg={12} className={"mb-1"}>
                <PreviewMultiImage handleFiles={handleUpdateFiles} />
              </Col>
              <Col lg={12} className={"d-flex justify-content-end align-items-center"}>
                <Button
                  type={"submit"}
                  color={"primary"}
                  disabled={isLoading}
                >
                  {isLoading ? (
                    <Spinner size={"sm"} className={"me-2"}>
                      Loading...
                    </Spinner>
                  ) : (
                    <i className={"ri-check-double-line me-2"}></i>
                  )}{" "}
                  Сохранить
                </Button>
              </Col>
            </Row>
          </Form>
        </ModalBody>
      </Modal>
    </React.Fragment>
  );
};

export default AddComment;
