import React, { useState } from "react";
import {
  Button,
  Col,
  Collapse,
  FormFeedback,
  Input,
  Label,
  Row,
  Spinner,
  TabPane,
} from "reactstrap";
import Popover from "../../../../components/Popover/Popover";
import { Error } from "../../../../components/Notification/Error";
import * as Yup from "yup";
import { useFormik } from "formik";
import { fetchWrapper } from "../../../../helpers/fetchWrapper";
import { useNavigate } from "react-router-dom";

const Price = ({ isAdded, dataForUpdate }) => {
  const [isFreeTax, setIsFreeTax] = useState(!dataForUpdate?.isFreeTax);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  const navigate = useNavigate();

  const taxPriceToggle = () => {
    setIsFreeTax(!isFreeTax);
  };

  const validation = useFormik({
    initialValues: {
      price: 0,
      isFreeTax: true,
      taxPrice: 1,
    },
    validationSchema: Yup.object({
      price: Yup.number()
        .min(100, "Цена товара должна быть больше 100 руб.")
        .max(1000000, "Цена товара не должна перевышать 1,000,000 руб.")
        .required("Заполните обязательное поле"),
      taxPrice: Yup.number()
        .min(1, "Цена за доставку должна быть больше 1 руб.")
        .max(10000, "Цена за доставку не должна перевышать 10,000 руб."),
    }),
    onSubmit: (values) => {
      setIsLoading(true);

      const data = {
        price: values.price,
        isFreeTax: isFreeTax,
        taxPrice: values.taxPrice,
        productId: dataForUpdate?.id,
      };

      fetchWrapper
        .put("api/product/updateproductprice", data)
        .then((response) => {
          setIsLoading(false);
          navigate("/admin/products");
        })
        .catch((error) => {
          setIsLoading(false);
          setError(error);
        });
    },
  });

  console.log(dataForUpdate.isFreeTax);

  return (
    <TabPane tabId={2}>
      {error ? <Error message={error} /> : null}
      {isAdded ? (
        isLoading ? (
          <div className={"d-flex justify-content-center align-items-center"}>
            <div className={"spinner-grow text-success"} role={"status"}>
              <span className={"visually-hidden"}>Loading...</span>
            </div>
          </div>
        ) : (
          <form
            className={"form-horizontal"}
            onSubmit={(e) => {
              e.preventDefault();
              validation.handleSubmit(e);
              return false;
            }}
          >
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
                    htmlFor={"price"}
                    id={"price"}
                  >
                    Цена продукта
                    <Popover
                      id={"price"}
                      placement={"top"}
                      text={"Цена продукта без учета доставки."}
                    />
                  </Label>
                </Col>
                <Col lg={8}>
                  <Input
                    type={"number"}
                    className={"form-control"}
                    name={"price"}
                    placeholder={"Введите цену"}
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                    defaultValue={dataForUpdate?.price || ""}
                    invalid={
                      !!(validation.touched.price && validation.errors.price)
                    }
                  />
                  {validation.touched.price && validation.errors.price ? (
                    <FormFeedback type="invalid">
                      {validation.errors.price}
                    </FormFeedback>
                  ) : null}
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
                    htmlFor={"isFreeTax"}
                    id={"isFreeTax"}
                  >
                    Бесплатная доставка?
                    <Popover
                      id={"isFreeTax"}
                      placement={"top"}
                      text={"ююююююююю"}
                    />
                  </Label>
                </Col>
                <Col lg={8}>
                  <div
                    className={
                      "form-check form-switch-warning form-switch form-switch-md"
                    }
                  >
                    <Input
                      type={"checkbox"}
                      className={"form-check-input form-check-input"}
                      role={"isFreeTax"}
                      id={"SwitchCheck4"}
                      name={"isFreeTax"}
                      defaultChecked={!isFreeTax}
                      onClick={taxPriceToggle}
                    />
                  </div>
                </Col>
              </Col>
              <Collapse isOpen={isFreeTax}>
                {" "}
                <Col
                  lg={12}
                  className={
                    "d-flex justify-content-between align-items-center mb-3"
                  }
                >
                  <Col lg={4}>
                    <Label
                      className={"form-label fs-16"}
                      htmlFor={"taxPrice"}
                      id={"taxPrice"}
                    >
                      Цена доставки
                      <Popover
                        id={"taxPrice"}
                        placement={"top"}
                        text={"Здесь вы указываете цену доставки."}
                      />
                    </Label>
                  </Col>
                  <Col lg={8}>
                    <Input
                      className={"form-control"}
                      type={"number"}
                      name={"taxPrice"}
                      placeholder={"Введите сумму доставки"}
                      onChange={validation.handleChange}
                      onBlur={validation.handleBlur}
                      defaultValue={dataForUpdate?.taxPrice || "1"}
                      invalid={
                        !!(
                          validation.touched.taxPrice &&
                          validation.errors.taxPrice
                        )
                      }
                    />
                    {validation.touched.taxPrice &&
                    validation.errors.taxPrice ? (
                      <FormFeedback type="invalid">
                        {validation.errors.taxPrice}
                      </FormFeedback>
                    ) : null}
                  </Col>
                </Col>
              </Collapse>
              <Col
                lg={12}
                className={"d-flex justify-content-end align-items-end"}
              >
                <Button
                  type={"submit"}
                  color={"primary"}
                  className={"btn btn-primary"}
                  disabled={isLoading}
                >
                  {isLoading ? (
                    <Spinner size={"sm"} className={"me-2"}>
                      Loading...
                    </Spinner>
                  ) : null}
                  <i className={"ri-check-double-line"}></i> Сохранить
                </Button>
              </Col>
            </Row>
          </form>
        )
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

export default Price;
