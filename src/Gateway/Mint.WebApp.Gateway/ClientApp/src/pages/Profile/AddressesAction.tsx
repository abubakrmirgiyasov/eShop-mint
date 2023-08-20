import React, { FC, useEffect, useState } from "react";
import { IUser, IUserAddress } from "../../services/types/IUser";
import {
  Button,
  Col,
  FormFeedback,
  Modal,
  ModalBody,
  ModalHeader,
  Row,
  Spinner,
} from "reactstrap";
import { Error } from "../../components/Notifications/Error";
import Select from "react-select";
import { Countries } from "../../constants/commonList";
import * as Yup from "yup";
import { useForm, Controller } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { fetch } from "../../helpers/fetch";
import CustomErrorStyle from "../../components/Common/CustomErrorStyle";

interface IAddressAction {
  user: IUser;
  address: IUserAddress;
  isEdit: boolean;
  isOpen: boolean;
  toggle: () => void;
  handleNewAddress: (address: IUserAddress) => void;
  handleUpdateAddress: (address: IUserAddress) => void;
}

const AddressesAction: FC<IAddressAction> = (props) => {
  const {
    user,
    address,
    isEdit,
    isOpen,
    toggle,
    handleUpdateAddress,
    handleNewAddress,
  } = props;

  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");

  const validation = Yup.object().shape({
    country: Yup.object().required("Выберете страну"),
    city: Yup.string()
      .required("Заполните обязательное поле")
      .min(3, "Минимальная длина строки 3 символа")
      .max(60, "Максимальная длина строки 60 символов"),
    zipCode: Yup.string()
      .required("Заполните обязательное поле")
      .matches(/^\d{6}(?:[-\s]\d{4})?$/, "Неверный формат почтового индекса"),
    fullAddress: Yup.string()
      .required("Заполните обязательное поле")
      .min(3, "Минимальная длина строки 3 символа")
      .max(60, "Максимальная длина строки 60 символов"),
    description: Yup.string(),
  });

  const {
    register,
    handleSubmit,
    control,
    reset,
    formState: { errors },
  } = useForm<IUserAddress>({
    resolver: yupResolver(validation),
  });

  useEffect(() => {
    reset();
  }, [toggle, reset]);

  const onSubmit = (values: IUserAddress) => {
    setIsLoading(true);

    values.email = user.email;
    values.fullName = `${user.firstName} ${user.secondName}`;
    values.phone = Number(user.phone);

    if (!isEdit) {
      fetch()
        .post("/user/createuseraddress", values)
        .then((response: IUserAddress) => {
          setIsLoading(false);
          reset();
          handleNewAddress(response);
          toggle();
        })
        .catch((error) => {
          setIsLoading(false);
          setError(error);
        });
    } else {
      values.id = address.id;
      fetch()
        .put("/user/updateuseraddress", values)
        .then((response: IUserAddress) => {
          setIsLoading(false);
          reset();
          handleUpdateAddress(response);
          toggle();
        })
        .catch((error) => {
          setIsLoading(false);
          setError(error);
        });
    }
  };

  return (
    <React.Fragment>
      {error && <Error message={error} />}
      <Modal isOpen={isOpen} toggle={toggle} className={"border-0"}>
        <ModalHeader
          className={"p-3 bg-soft-white border-bottom-dashed"}
          toggle={toggle}
          style={{ borderBottom: "1px" }}
        >
          {isEdit ? "Изменить адрес" : "Добавить адрес"}
        </ModalHeader>
        <ModalBody className={"modal-body"}>
          <form onSubmit={handleSubmit(onSubmit)}>
            <Row>
              <Col lg={12} className={"form-group mb-3"}>
                <label htmlFor={"country"} className={"form-label"}>
                  Страна
                </label>
                <Controller
                  name={"country"}
                  control={control}
                  render={({ field }) => (
                    <Select
                      {...field}
                      options={Countries || []}
                      // defaultValue={}
                    />
                  )}
                />
                <CustomErrorStyle message={errors.country?.message} />
              </Col>
              <Col lg={6} className={"form-group mb-3"}>
                <label className={"form-label"} htmlFor={"city"}>
                  Город
                </label>
                <input
                  type={"text"}
                  className={`form-control ${errors.city ? "is-invalid" : ""}`}
                  placeholder={"Введите ваш город"}
                  id={"city"}
                  defaultValue={address?.city || ""}
                  {...register("city")}
                />
                <FormFeedback type={"invalid"}>
                  {errors.city?.message}
                </FormFeedback>
              </Col>
              <Col lg={6}>
                <label className={"form-label"} htmlFor={"zipCode"}>
                  Почтовый индекс
                </label>
                <input
                  type={"number"}
                  className={`form-control ${
                    errors.zipCode ? "is-invalid" : ""
                  }`}
                  placeholder={"Ваш почтовый индекс"}
                  id={"zipCode"}
                  defaultValue={address?.zipCode || ""}
                  {...register("zipCode")}
                />
                <FormFeedback type={"invalid"}>
                  {errors.zipCode?.message}
                </FormFeedback>
              </Col>
              <Col lg={12} className={"form-group mb-3"}>
                <label className={"form-label"} htmlFor={"street"}>
                  Улица
                </label>
                <input
                  type={"text"}
                  className={`form-control ${
                    errors.street ? "is-invalid" : ""
                  }`}
                  placeholder={"Введите вашу улицу"}
                  id={"address"}
                  defaultValue={address?.street || ""}
                  {...register("street")}
                />
                <FormFeedback type={"invalid"}>
                  {errors.street?.message}
                </FormFeedback>
              </Col>
              <Col lg={12} className={"form-group mb-3"}>
                <label className={"form-label"} htmlFor={"address"}>
                  Адрес
                </label>
                <input
                  type={"text"}
                  className={`form-control ${
                    errors.fullAddress ? "is-invalid" : ""
                  }`}
                  placeholder={"Введите ваш адрес"}
                  id={"address"}
                  defaultValue={address?.fullAddress || ""}
                  {...register("fullAddress")}
                />
                <FormFeedback type={"invalid"}>
                  {errors.fullAddress?.message}
                </FormFeedback>
              </Col>
              <Col lg={12} className={"form-group mb-3"}>
                <label className={"form-label"} htmlFor={"description"}>
                  Описание
                </label>
                <textarea
                  className={`form-control`}
                  placeholder={"Дополнительные сведения"}
                  id={"description"}
                  defaultValue={address?.description || ""}
                  {...register("description")}
                ></textarea>
              </Col>
              <div className={"d-flex justify-content-end align-items-center"}>
                <Button
                  type={"button"}
                  color={"danger"}
                  className={"me-3"}
                  onClick={toggle}
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
          </form>
        </ModalBody>
      </Modal>
    </React.Fragment>
  );
};

export default AddressesAction;
