import React, { useEffect, useState } from "react";
import {
  Button,
  Card,
  CardBody,
  CardHeader,
  Col,
  Container,
  Form,
  FormFeedback,
  Input,
  Label,
  Row,
  Spinner,
} from "reactstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { CKEditor } from "@ckeditor/ckeditor5-react";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { useFormik } from "formik";
import { fetchWrapper } from "../../../helpers/fetchWrapper";
import { Error } from "../../../components/Notification/Error";
import Breadcrumb from "../../../components/Breadcrumb/Breadcrumb";
import Popover from "../../../components/Popover/Popover";
import PreviewSingleImage from "../../components/Dropzone/PreviewSingleImage";
import * as Yup from "yup";

const ManufacturesAction = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [imageFile, setImageFile] = useState(null);
  const [data, setData] = useState([]);
  const [getDataLaoading, setGetDataLoading] = useState(false);

  const navigate = useNavigate();
  const params = useParams();

  useEffect(() => {
    if (params.id) {
      setGetDataLoading(true);
      fetchWrapper
        .get(`api/manufacture/getmanufacturebyid/${params.id}`)
        .then((response) => {
          setGetDataLoading(false);
          setData(response);
        })
        .catch((error) => {
          setGetDataLoading(false);
          setError(error);
        });
    }
  }, [params.id]);

  const validation = useFormik({
    enableReinitialize: true,
    initialValues: {
      name: "",
      displayOrder: 0,
      image: null,
      description: "",
    },
    validationSchema: Yup.object({
      name: Yup.string().required("Заполните обязательное поле"),
    }),
    onSubmit: (values) => {
      setIsLoading(true);

      const formData = new FormData();
      formData.append("name", values.name);
      formData.append("displayOrder", values.displayOrder);
      formData.append("description", values.description);

      if (imageFile) {
        formData.append("folder", "manufacture");
        formData.append("photo", imageFile[0]);
      }

      if (params.id) {
        formData.append("id", params.id);
        fetchWrapper
          .put("api/manufacture/updatemanufacture", formData, false)
          .then((response) => {
            setIsLoading(false);
            navigate("/admin/manufactures");
          })
          .catch((error) => {
            setError(error);
            setIsLoading(false);
          });
      } else {
        fetchWrapper
          .post("api/manufacture/addmanufacture", formData, false)
          .then((response) => {
            setIsLoading(false);
            navigate("/admin/manufactures");
          })
          .catch((error) => {
            setError(error);
            setIsLoading(false);
          });
      }
    },
  });

  function setSelectedImage(image) {
    setImageFile(image);
  }

  return (
    <div className="page-content">
      {error ? <Error message={error} /> : null}
      <Container fluid>
        <Breadcrumb
          title={
            !params.id
              ? "Добавить нового производителя"
              : "Изменить производителя"
          }
          pageTitle={"Производители"}
          link={"/admin/manufactures"}
        />
        <Card>
          <CardHeader>
            <h3 className="fs-20 fw-bold">
              <Link to="/admin/manufactures" className="btn btn-light">
                <i className="ri-arrow-left-line"></i>
              </Link>{" "}
              {!params.id
                ? "Добавить нового производителя"
                : "Изменить пользователя"}
            </h3>
          </CardHeader>
          <CardBody>
            {params.id && getDataLaoading ? (
              <div className="d-flex justify-content-center align-items-center">
                <div className="spinner text-success" role="status">
                  <span className="visually-hidden">Loading...</span>
                </div>
              </div>
            ) : (
              <Row>
                <Form
                  onSubmit={(e) => {
                    e.preventDefault();
                    validation.handleSubmit(e);
                    return false;
                  }}
                >
                  <Col lg={12} className="mb-3">
                    <Row className="align-items-center">
                      <Col xl={2}>
                        <Label className="form-label fw-bold">
                          Отобразить по порядку{" "}
                          <Popover
                            placement={"right"}
                            text={`Задает порядок отображения.  1 представляет вершину списка.`}
                            id={"displayOrder"}
                          />
                        </Label>
                      </Col>
                      <Col xl={10}>
                        <Input
                          type="number"
                          name="displayOrder"
                          className="form-control"
                          placeholder="Отобразить по порядку"
                          onChange={validation.handleChange}
                          onBlur={validation.handleBlur}
                          defaultValue={
                            validation.values.displayOrder ||
                            data.displayOrder ||
                            ""
                          }
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className="mb-3">
                    <Row className="align-items-center">
                      <Col xl={2}>
                        <Label className="form-label fw-bold">
                          Название{" "}
                          <Popover
                            placement={"right"}
                            text={`Название производителя.`}
                            id={"name"}
                          />
                        </Label>
                      </Col>
                      <Col xl={10}>
                        <Input
                          type="text"
                          name="name"
                          className="form-control"
                          placeholder="Название"
                          onChange={validation.handleChange}
                          onBlur={validation.handleBlur}
                          defaultValue={
                            validation.values.name || data.name || ""
                          }
                          invalid={
                            !!(
                              validation.touched.name && validation.errors.name
                            )
                          }
                        />
                        {validation.touched.name && validation.errors.name ? (
                          <FormFeedback type="invalid">
                            {validation.errors.name}
                          </FormFeedback>
                        ) : null}
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className="mb-3">
                    <Row className="align-items-center">
                      <Col xl={2}>
                        <Label className="form-label fw-bold">
                          Картинка{" "}
                          <Popover
                            placement={"right"}
                            text={`Картинка производителя.`}
                            id={"image"}
                          />
                        </Label>
                      </Col>
                      <Col xl={10}>
                        <PreviewSingleImage
                          setSelectedImage={setSelectedImage}
                          image={data?.photo}
                          name={data?.name}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className="mb-3">
                    <Row className="align-items-center">
                      <Col xl={2}>
                        <Label className="form-label fw-bold">
                          Описание{" "}
                          <Popover
                            placement={"right"}
                            text={`Картинка производителя.`}
                            id={"image"}
                          />
                        </Label>
                      </Col>
                      <Col xl={10}>
                        <CKEditor
                          editor={ClassicEditor}
                          id="text"
                          onChange={(event, editor) => {
                            validation.values.description = editor.getData();
                          }}
                          data={data?.description || ""}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col
                    lg={12}
                    className={"d-flex justify-content-end align-items-end"}
                  >
                    <Button
                      color={"primary"}
                      type={"submit"}
                      disabled={isLoading}
                    >
                      {isLoading ? (
                        <Spinner size={"sm"}>Loading...</Spinner>
                      ) : null}
                      <i className={"ri-check-double-fill"}></i> Сохранить
                    </Button>
                  </Col>
                </Form>
              </Row>
            )}
          </CardBody>
        </Card>
      </Container>
    </div>
  );
};

export default ManufacturesAction;
