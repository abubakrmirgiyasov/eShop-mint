import React, { useEffect, useState } from "react";
import { Button, Col, Input, Label, Row, Spinner, TabPane } from "reactstrap";
import { useFormik } from "formik";
import * as Yup from "yup";
import { Error } from "../../../../components/Notification/Error";
import { Success } from "../../../../components/Notification/Success";
import Popover from "../../../../components/Popover/Popover";
import { fetchWrapper } from "../../../../helpers/fetchWrapper";

const Characteristics = ({ isAdded, dataForUpdate }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(null);
  const [color, setColor] = useState(null);

  const handleColorChange = (e) => {
    setColor(e.target.value);
  };

  const validation = useFormik({
    initialValues: {
      material: "",
      color: "",
      weight: 0,
      length: 0,
      width: 0,
      height: 0,
      releaseDate: "2023-01-01",
      garanty: 0,
    },
    validationSchema: Yup.object({
      weight: Yup.number().notRequired(),
      length: Yup.number().notRequired(),
      width: Yup.number().notRequired(),
      height: Yup.number().notRequired(),
      garanty: Yup.number().notRequired(),
    }),
    onSubmit: (values) => {
      setIsLoading(true);

      const data = {
        material: values.material,
        color: color,
        weight: values.weight,
        length: values.length,
        width: values.width,
        height: values.height,
        releaseDate: values.releaseDate,
        garanty: values.garanty,
        productId: dataForUpdate?.id,
      };

      fetchWrapper
        .put("api/product/updateproductcharacteristic", data)
        .then((response) => {
          setIsLoading(false);
          setSuccess(response);
        })
        .catch((error) => {
          setIsLoading(false);
          setError(error);
        });
    },
  });

  return (
    <TabPane tabId={7}>
      {isAdded ? (
        <form
          className={"form-horizontal"}
          onSubmit={(e) => {
            e.preventDefault();
            validation.handleSubmit(e);
            return false;
          }}
        >
          {error ? <Error message={error} /> : null}
          {success ? <Success message={success.message} /> : null}
          <Row>
            <Col
              lg={12}
              className={
                "d-flex justify-content-between align-items-center mb-3"
              }
            >
              <Col lg={4}>
                <Label
                  className={"form-label fs-16"}
                  htmlFor={"material"}
                  id={"material"}
                >
                  Материал
                  <Popover
                    id={"material"}
                    placement={"top"}
                    text={
                      "Материал вашего продукта, из чего оно сделано и т.д."
                    }
                  />
                </Label>
              </Col>
              <Col lg={8}>
                <Input
                  type={"text"}
                  className={"form-control"}
                  name={"material"}
                  placeholder={"Введите название материала"}
                  onChange={validation.handleChange}
                  onBlur={validation.handleBlur}
                  defaultValue={
                    validation.values.material ||
                    dataForUpdate?.commonCharacteristic?.material ||
                    ""
                  }
                />
              </Col>
            </Col>
            <Col
              lg={12}
              className={
                "d-flex justify-content-between align-items-center mb-3"
              }
            >
              <Col lg={4}>
                <Label
                  className={"form-label fs-16"}
                  htmlFor={"color"}
                  id={"color"}
                >
                  Цвет
                  <Popover
                    id={"color"}
                    placement={"top"}
                    text={"Цвет вашего продукта."}
                  />
                </Label>
              </Col>
              <Col lg={6} className={"me-2"}>
                <Input
                  type={"color"}
                  className={"form-control"}
                  defaultValue={dataForUpdate?.color || ""}
                  onChange={handleColorChange}
                />
              </Col>
              <Col lg={2}>
                <Input
                  type={"text"}
                  className={"form-control h-100"}
                  name={"color"}
                  defaultValue={
                    color || dataForUpdate?.commonCharacteristic?.color || ""
                  }
                />
              </Col>
            </Col>
            <Col
              lg={12}
              className={
                "d-flex justify-content-between align-items-center mb-3"
              }
            >
              <Col lg={4}>
                <Label
                  className={"form-label fs-16"}
                  htmlFor={"size"}
                  id={"size"}
                >
                  Объем товара
                  <Popover
                    id={"size"}
                    placement={"top"}
                    text={"Вес и длина товара в г/м."}
                  />
                </Label>
              </Col>
              <Col lg={4} className={"me-2"}>
                <Input
                  type={"number"}
                  className={"form-control"}
                  name={"weight"}
                  placeholder={"Введите вес товара (г)"}
                  onChange={validation.handleChange}
                  onBlur={validation.handleBlur}
                  defaultValue={
                    validation.values.weight ||
                    dataForUpdate?.commonCharacteristic?.weight ||
                    ""
                  }
                />
              </Col>
              <Col lg={4}>
                <Input
                  type={"number"}
                  className={"form-control"}
                  name={"length"}
                  placeholder={"Введите длину товара (см)"}
                  onChange={validation.handleChange}
                  onBlur={validation.handleBlur}
                  defaultValue={
                    validation.values.length ||
                    dataForUpdate?.commonCharacteristic?.length ||
                    ""
                  }
                />
              </Col>
            </Col>
            <Col
              lg={12}
              className={
                "d-flex justify-content-between align-items-center mb-3"
              }
            >
              <Col lg={4}>
                <Label className={"form-label fs-16"} htmlFor={"wh"} id={"wh"}>
                  Размер товара
                  <Popover
                    id={"wh"}
                    placement={"top"}
                    text={"Высота и ширина товара в метрах."}
                  />
                </Label>
              </Col>
              <Col lg={4} className={"me-2"}>
                <Input
                  type={"number"}
                  className={"form-control"}
                  name={"width"}
                  placeholder={"Введите ширину товара (см)"}
                  onChange={validation.handleChange}
                  onBlur={validation.handleBlur}
                  defaultValue={
                    validation.values.width ||
                    dataForUpdate?.commonCharacteristic?.width ||
                    ""
                  }
                />
              </Col>
              <Col lg={4}>
                <Input
                  type={"number"}
                  className={"form-control"}
                  name={"height"}
                  placeholder={"Введите высоту товара (см)"}
                  onChange={validation.handleChange}
                  onBlur={validation.handleBlur}
                  defaultValue={
                    validation.values.height ||
                    dataForUpdate?.commonCharacteristic?.height ||
                    ""
                  }
                />
              </Col>
            </Col>
            <Col
              lg={12}
              className={
                "d-flex justify-content-between align-items-center mb-3"
              }
            >
              <Col lg={4}>
                <Label
                  className={"form-label fs-16"}
                  htmlFor={"releaseDate"}
                  id={"releaseDate"}
                >
                  Даты
                  <Popover
                    id={"releaseDate"}
                    placement={"top"}
                    text={
                      "Дата релиза и срок годности продукта (указываете в месяце, например: 12)"
                    }
                  />
                </Label>
              </Col>
              <Col lg={4} className={"me-2"}>
                <Input
                  type={"date"}
                  className={"form-control"}
                  name={"releaseDate"}
                  onChange={validation.handleChange}
                  onBlur={validation.handleBlur}
                  defaultValue={
                    validation.values.releaseDate ||
                    dataForUpdate?.commonCharacteristic?.releaseDate ||
                    ""
                  }
                />
              </Col>
              <Col lg={4}>
                <Input
                  type={"number"}
                  className={"form-control"}
                  name={"garanty"}
                  placeholder={"Введите срок годности"}
                  onChange={validation.handleChange}
                  onBlur={validation.handleBlur}
                  defaultValue={
                    validation.values.garanty ||
                    dataForUpdate?.commonCharacteristic?.garanty ||
                    ""
                  }
                />
              </Col>
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
                <i className={"ri-check-double-line"}></i> Сохранить
              </Button>
            </Col>
          </Row>
        </form>
      ) : (
        <div className={"d-flex flex-column align-items-center"}>
          <h3 className={"text-center"}>
            Сначала вам нужно создать товар, чтобы заполнить остальные поля.
          </h3>
          <h5 className={"text-center text-muted fs-14 mt-3"}>
            Вернитесь на вкладку Информация чтобы создать.
          </h5>
        </div>
      )}
    </TabPane>
  );
};

export default Characteristics;
