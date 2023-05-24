import React, { useState } from "react";
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
import * as Yup from "yup";
import { Error } from "../../../components/Notification/Error";
import { fetchWrapper } from "../../../helpers/fetchWrapper";
import { useFormik } from "formik";

const PromotionsAction = ({
  isOpen,
  toggle,
  dataForUpdate,
  newData,
  updatedData,
}) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  const validation = useFormik({
    initialValues: {
      name: "",
      percent: "",
      untilDate: "",
    },
    validationSchema: Yup.object({
      name: Yup.string().required("Заполните обязательное поле"),
      percent: Yup.number()
        .min(1)
        .max(100)
        .required("Заполните обязательное поле"),
      untilDate: Yup.string().required("Заполните обязательное поле"),
    }),
    onSubmit: (values) => {
      setIsLoading(true);

      const data = {
        id: updatedData?.id,
        name: values.name,
        percent: values.percent,
        untilDate: values.untilDate,
      };

      if (updatedData) {
        fetchWrapper
          .put("api/discount/updatepromotion", data)
          .then((response) => {
            setIsLoading(false);
            dataForUpdate(data);
            toggle();
          })
          .catch((error) => {
            setIsLoading(false);
            setError(error);
          });
      } else {
        fetchWrapper
          .post("api/discount/addpromotion", data)
          .then((response) => {
            setIsLoading(false);
            newData(response);
            toggle();
          })
          .catch((error) => {
            setError(error);
            setIsLoading(false);
          });
      }
    },
  });

  return (
    <React.Fragment>
      <Modal
        isOpen={isOpen}
        toggle={toggle}
        className={"border-0"}
        modalClassName={"modal-xxl fade zoomIn"}
      >
        <ModalHeader
          className={"p-3 bg-soft-white border-bottom-dashed"}
          toggle={toggle}
          style={{ borderBottom: "1px" }}
        >
          {updatedData ? "Изменить" : "Добавить"}
        </ModalHeader>
        <ModalBody className={"modal-body"}>
          {error ? <Error message={error.message} /> : null}
          <Form
            onSubmit={(e) => {
              e.preventDefault();
              validation.handleSubmit(e);
              return false;
            }}
          >
            <Row>
              <Col lg={12}>
                <div className={"form-group mb-3"}>
                  <Label className={"form-label"} htmlFor={"name"}>
                    Название
                  </Label>
                  <Input
                    type={"text"}
                    className={"form-control"}
                    id={"name"}
                    placeholder={"Введите название"}
                    defaultValue={updatedData?.name || ""}
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                    invalid={
                      !!(validation.touched.name && validation.errors.name)
                    }
                  />
                  {validation.touched.name && validation.errors.name ? (
                    <FormFeedback type="invalid">
                      {validation.errors.name}
                    </FormFeedback>
                  ) : null}
                </div>
              </Col>
              <Col lg={12}>
                <div className={"form-group mb-3"}>
                  <Label className={"form-label"} htmlFor={"percent"}>
                    Процент %
                  </Label>
                  <Input
                    type={"number"}
                    className={"form-control"}
                    id={"percent"}
                    placeholder={"Введите процент"}
                    defaultValue={updatedData?.percent || ""}
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                    invalid={
                      !!(
                        validation.touched.percent && validation.errors.percent
                      )
                    }
                  />
                  {validation.touched.percent && validation.errors.percent ? (
                    <FormFeedback type="invalid">
                      {validation.errors.percent}
                    </FormFeedback>
                  ) : null}
                </div>
              </Col>
              <Col lg={12}>
                <div className={"form-group mb-3"}>
                  <Label className={"form-label"} htmlFor={"untilDate"}>
                    Действителен до
                  </Label>
                  <Input
                    type={"date"}
                    id={"untilDate"}
                    className={"form-control"}
                    placeholder={"Введите процент"}
                    defaultValue={updatedData?.activeDateUntil || ""}
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                    invalid={
                      !!(
                        validation.touched.untilDate &&
                        validation.errors.untilDate
                      )
                    }
                  />
                  {validation.touched.untilDate &&
                  validation.errors.untilDate ? (
                    <FormFeedback type="invalid">
                      {validation.errors.untilDate}
                    </FormFeedback>
                  ) : null}
                </div>
              </Col>
              <Col
                lg={12}
                className={"d-flex justify-content-end align-items-center"}
              >
                <Button
                  type={"submit"}
                  className={"btn btn-primary"}
                  color={"primary"}
                  disabled={isLoading}
                >
                  {isLoading ? (
                    <Spinner className={"me-2"} size={"sm"}>
                      Loading...
                    </Spinner>
                  ) : null}
                  <i className={"ri-check-double-fill"}></i> Сохранить
                </Button>
              </Col>
            </Row>
          </Form>
        </ModalBody>
      </Modal>
    </React.Fragment>
  );
};

export default PromotionsAction;
