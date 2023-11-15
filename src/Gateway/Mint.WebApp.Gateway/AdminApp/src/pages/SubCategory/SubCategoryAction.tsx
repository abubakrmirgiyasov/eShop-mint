import React, { FC, useEffect, useState } from "react";
import { Error } from "../../../components/Notifications/Error";
import {
  Card,
  CardBody,
  CardHeader,
  Col,
  Container,
  FormFeedback,
  Row,
  Spinner,
} from "reactstrap";
import BreadCrumb from "../../../components/Common/BreadCrumb";
import { Link, useParams } from "react-router-dom";
import Popover from "../../../components/Common/Popover";
import * as Yup from "yup";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { ISubCategory } from "../../../services/types/ISubCategory";
import { fetch } from "../../../helpers/fetch";
import ReactSelect from "react-select";
import { ISampleType } from "../../../services/types/ICommon";

const SubCategoryAction: FC = () => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");
  const [subCategories, setSubCategories] = useState<ISampleType[]>([]);

  const params = useParams();

  useEffect(() => {
    setIsLoading(true);

    fetch()
      .get("/gate/category/getSampleCategories")
      .then((response: ISampleType[]) => {
        setSubCategories(response);
        setIsLoading(false);
      })
      .catch((error) => {
        setError(error);
        setIsLoading(false);
      });
    if (params.id) {
    } else {
    }
  }, [params]);

  const validation = Yup.object().shape({
    displayOrder: Yup.number()
      .min(1, "Число должно быть в диапазоне от 1 до 99.")
      .max(99, "Число должно быть в диапазоне от 1 до 99"),
    name: Yup.string()
      .required("Заполните обязательное поле")
      .min(3, "Минимальная длина строки 3 символа")
      .max(100, "Максимальная длина строки 100 символов"),
    fullName: Yup.string()
      .min(3, "Минимальная длина строки 3 символа")
      .max(400, "Максимальная длина строки 400 символов"),
    defaultLink: Yup.string()
      .min(3, "Минимальная длина строки 3 символа")
      .max(60, "Максимальная длина строки 60 символов"),
  });

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<ISubCategory>({
    resolver: yupResolver(validation),
  });

  const onSubmit = (values: ISubCategory) => {
    fetch()
      .post("/gate/subCategory/newSubCategory", values)
      .then((r) => {
        reset();
      })
      .catch((e) => {
        setError(e);
      })
      .finally(() => setIsLoading(false));
  };

  return (
    <div className={"page-content"}>
      {error && <Error message={error} />}
      <Container fluid>
        <BreadCrumb
          currentPage={params.id ? "Изменить" : "Добавить"}
          linkToPage={"/admin/categories"}
          pageTitle={"Категории"}
        />
        <Card>
          <CardHeader>
            <h3 className={"fs-20 fw-bold mb-0"}>
              <Link to={"/admin/categories"} className={"btn btn-light me-2"}>
                <i className={"ri-arrow-left-line"}></i>
              </Link>{" "}
              {params.id ? "Изменить категорию" : "Добавить новую категорию"}
            </h3>
          </CardHeader>
          <CardBody>
            {isLoading ? (
              <div>
                <Spinner color={"success"} size={"sm"}>
                  Loading...
                </Spinner>
              </div>
            ) : (
              <form onSubmit={handleSubmit(onSubmit)}>
                <Row>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label className={"form-label fw-bold mb-0"}>
                          Отобразить по порядку{" "}
                          <Popover
                            placement={"right"}
                            text={`Задает порядок отображения.  1 представляет вершину списка.`}
                            id={"displayOrder"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <input
                          type={"number"}
                          className={`form-control ${
                            errors.displayOrder ? "is-invalid" : ""
                          }`}
                          placeholder={"Отобразить по порядку"}
                          defaultValue={""}
                          {...register("displayOrder")}
                        />
                        <FormFeedback type={"invalid"}>
                          {errors.displayOrder?.message}
                        </FormFeedback>
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label className={"form-label fw-bold mb-0"}>
                          Родаитель{" "}
                          <Popover
                            placement={"right"}
                            text={`Задает элементу родителя.`}
                            id={"name"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <ReactSelect
                          isSearchable={true}
                          placeholder={"Выберите родителя"}
                          options={subCategories}
                        />
                        <FormFeedback type={"invalid"}>
                          {errors.name?.message}
                        </FormFeedback>
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label className={"form-label fw-bold mb-0"}>
                          Название{" "}
                          <Popover
                            placement={"right"}
                            text={`Задает название элементу.`}
                            id={"name"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <input
                          type={"text"}
                          className={`form-control ${
                            errors.name ? "is-invalid" : ""
                          }`}
                          placeholder={"Введите название"}
                          defaultValue={""}
                          {...register("name")}
                        />
                        <FormFeedback type={"invalid"}>
                          {errors.name?.message}
                        </FormFeedback>
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label className={"form-label fw-bold mb-0"}>
                          Полное название{" "}
                          <Popover
                            placement={"right"}
                            text={`Задает полное название текущему элементу.`}
                            id={"fullName"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <input
                          type={"text"}
                          className={`form-control ${
                            errors.fullName ? "is-invalid" : ""
                          }`}
                          placeholder={"Введите полное название"}
                          defaultValue={""}
                          {...register("fullName")}
                        />
                        <FormFeedback type={"invalid"}>
                          {errors.fullName?.message}
                        </FormFeedback>
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label className={"form-label fw-bold mb-0"}>
                          Ссылка по умолчанию{" "}
                          <Popover
                            placement={"right"}
                            text={`Задает ссылку для данного элемента.`}
                            id={"defaultLink"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <input
                          type={"text"}
                          className={`form-control ${
                            errors.defaultLink ? "is-invalid" : ""
                          }`}
                          placeholder={"Введите ссылку по умолчанию"}
                          defaultValue={""}
                          {...register("defaultLink")}
                        />
                        <FormFeedback type={"invalid"}>
                          {errors.defaultLink?.message}
                        </FormFeedback>
                      </Col>
                    </Row>
                  </Col>
                  <Col
                    className={"d-flex justify-content-end align-items-center"}
                    xl={12}
                  >
                    <button type={"submit"} className={"btn btn-success"}>
                      {isLoading ? (
                        <Spinner size={"sm"} className={"me-2"}>
                          Loading...
                        </Spinner>
                      ) : (
                        <i className={"ri-check-double-fill me-2"}></i>
                      )}
                      Сохранить
                    </button>
                  </Col>
                </Row>
              </form>
            )}
          </CardBody>
        </Card>
      </Container>
    </div>
  );
};

export default SubCategoryAction;
