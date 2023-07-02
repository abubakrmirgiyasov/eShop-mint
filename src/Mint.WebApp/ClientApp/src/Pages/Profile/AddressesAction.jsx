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
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { Error } from "../../components/Notification/Error";
import { Countries } from "../../constants/Common";
import Select from "react-select";
import * as Yup from "yup";
import { useFormik } from "formik";
import MySelect from "../../components/Forms/Select";

const AddressesAction = (props) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  const [country, setCountry] = useState(null);
  const [isCountryValid, setIsCountryValid] = useState(true);

  const validation = useFormik({
    enableReinitialize: true,
    initialValues: {
      fullAddress: props.address?.address || "",
      country: props.address?.country || "",
      city: props.address?.city || "",
      zipCode: props.address?.zipCode || "",
      description: props.address?.description || "",
    },
    validationSchema: Yup.object({
      fullAddress: Yup.string()
        .required("Заполните обязательное поле")
        .max(255, "Превышено макс. длина строки (255)")
        .min(4, "Минисальная длина строки 4 символа"),
      city: Yup.string()
        .required("Заполните обязательное поле")
        .max(60, "Превышено макс. длина строки (60).")
        .min(2, "Минисальная длина строки 2 символа"),
      zipCode: Yup.number()
        .required("Заполните обязательное поле")
        .max(999999, "Почтовый индекс не может быть больше 999 999")
        .min(10000, "Почтовый индекс не может быть меньше 10 000"),
      description: Yup.string()
        .notRequired()
        .max(777, "Превышено макс. длина строки (777)."),
    }),
    onSubmit: (values) => {
      if (!country) {
        setIsCountryValid(false);
        return false;
      }

      setIsLoading(true);

      const address = {
        id: props.address?.id,
        fullAddress: values.fullAddress,
        country: country,
        city: values.city,
        zipCode: values.zipCode,
        description: values.description,
        userId: props.userId,
      };

      if (!!props.isEdit) {
        fetchWrapper
          .put("api/user/updateuseraddress", address)
          .then(() => {
            setIsLoading(false);
            props.toggle();
            props.setUpdatedAdress(address);
          })
          .catch((error) => {
            setError(error);
            setIsLoading(false);
          });
      } else {
        fetchWrapper
          .post("api/user/adduseraddress", address)
          .then((response) => {
            setIsLoading(false);
            props.toggle();
            props.setNewAddress(response);
          })
          .catch((error) => {
            setError(error);
            setIsLoading(false);
          });
      }
    },
  });

  const handleCountryChange = (e) => {
    setCountry(e.label);
    setIsCountryValid(true);
  };

  return (
    <React.Fragment>
      <Modal
        isOpen={props.isOpen}
        toggle={props.toggle}
        className={"border-0"}
        modalClassName={"modal-xxl fade zoomIn"}
      >
        {error ? <Error message={error.message} /> : null}
        <ModalHeader
          className={"p-3 bg-soft-white border-bottom-dashed"}
          toggle={props.toggle}
          style={{ borderBottom: "1px" }}
        >
          {!!props.isEdit ? "Изменить адрес" : "Добавить адрес"}
        </ModalHeader>
        <ModalBody className={"modal-body"}>
          <Form
            onSubmit={(e) => {
              e.preventDefault();
              validation.handleSubmit(e);
              return false;
            }}
          >
            <Row>
              <Col lg={12} className={"mb-3"}>
                <MySelect
                  id={"country"}
                  name={"country"}
                  defaultValue={Countries.find(
                    (x) => x.label === props.address?.country
                  )}
                  options={Countries}
                  isRequired={isCountryValid}
                  onChange={handleCountryChange}
                  label={"Страна"}
                  placeholder={"Выберите страну"}
                />
              </Col>
              <Col lg={6}>
                <div className={"form-group mb-3"}>
                  <Label className={"form-label"} htmlFor={"city"}>
                    Город
                  </Label>
                  <Input
                    type={"text"}
                    className={"form-control"}
                    placeholder={"Введите ваш город"}
                    id={"city"}
                    name={"city"}
                    defaultValue={props.address?.city || ""}
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                    invalid={
                      !!(validation.touched.city && validation.errors.city)
                    }
                  />
                  {validation.touched.city && validation.errors.city ? (
                    <FormFeedback typeof={"invalid"}>
                      {validation.errors.city}
                    </FormFeedback>
                  ) : null}
                </div>
              </Col>
              <Col lg={6}>
                <div className={"form-group mb-3"}>
                  <Label className={"form-label"} htmlFor={"zipCode"}>
                    Почтовый индекс
                  </Label>
                  <Input
                    type={"number"}
                    className={"form-control"}
                    placeholder={"Ваш почтовый индекс"}
                    id={"zipCode"}
                    name={"zipCode"}
                    defaultValue={props.address?.zipCode || ""}
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                    invalid={
                      !!(
                        validation.touched.zipCode && validation.errors.zipCode
                      )
                    }
                  />
                  {validation.touched.zipCode && validation.errors.zipCode ? (
                    <FormFeedback typeof={"invalid"}>
                      {validation.errors.zipCode}
                    </FormFeedback>
                  ) : null}
                </div>
              </Col>
              <Col lg={12}>
                <div className={"form-group mb-3"}>
                  <Label className={"form-label"} htmlFor={"fullAddress"}>
                    Адрес
                  </Label>
                  <Input
                    type={"text"}
                    className={"form-control"}
                    placeholder={"Введите ваш адрес"}
                    id={"fullAddress"}
                    name={"fullAddress"}
                    defaultValue={props.address?.address || ""}
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                    invalid={
                      !!(
                        validation.touched.fullAddress &&
                        validation.errors.fullAddress
                      )
                    }
                  />
                  {validation.touched.fullAddress &&
                  validation.errors.fullAddress ? (
                    <FormFeedback typeof={"invalid"}>
                      {validation.errors.fullAddress}
                    </FormFeedback>
                  ) : null}
                </div>
              </Col>
              <Col lg={12}>
                <div className={"form-group mb-3"}>
                  <Label className={"form-label"} htmlFor={"description"}>
                    Описание
                  </Label>
                  <textarea
                    className={"form-control"}
                    placeholder={"Дополнительные сведения"}
                    id={"description"}
                    name={"description"}
                    defaultValue={props.address?.description || ""}
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                  ></textarea>
                  {validation.touched.description &&
                  validation.errors.description ? (
                    <FormFeedback typeof={"invalid"}>
                      {validation.errors.description}
                    </FormFeedback>
                  ) : null}
                </div>
              </Col>
              <div className={"d-flex justify-content-end align-items-center"}>
                <Button
                  type={"button"}
                  color={"danger"}
                  className={"me-3"}
                  onClick={props.toggle}
                >
                  <i className={"ri-close-line"}></i> Отмена
                </Button>
                <Button type={"submit"} color={"success"} disabled={isLoading}>
                  {isLoading ? (
                    <Spinner size={"sm"} className={"me-2"}>
                      Loading...
                    </Spinner>
                  ) : (
                    <i className={"ri-check-double-fill"}></i>
                  )}{" "}
                  Сохранить
                </Button>
              </div>
            </Row>
          </Form>
        </ModalBody>
      </Modal>
    </React.Fragment>
  );
};

export default AddressesAction;
