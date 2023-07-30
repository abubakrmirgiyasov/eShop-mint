import React, { ChangeEvent, FC, useState } from "react";
import { IUser } from "../../services/types/IUser";
import {
  Button,
  Card,
  CardBody,
  Col,
  FormFeedback,
  Row,
  TabPane,
} from "reactstrap";
import { Link } from "react-router-dom";
import CustomDivider from "../../components/Common/CustomDivider";
import * as Yup from "yup";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import PhoneInput from "react-phone-input-2";
import { ILanguage } from "../../services/types/ICommon";
import SingleImage from "../../components/Dropzone/SingleImage";
import { CKEditor } from "@ckeditor/ckeditor5-react";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { dateConverter } from "../../helpers/dateConverter";

interface ICustomerInfo {
  user: IUser;
  language: ILanguage;
}

interface IUserInfo {
  gender: string;
  firstName: string;
  secondName: string;
  lastName?: string;
  dateBirth: string;
  email: string;
  phone: number;
  photo?: File;
  description?: string;
}

const CustomerInfo: FC<ICustomerInfo> = ({ user, language }) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [isEdit, setIsEdit] = useState<boolean>(true);
  const [photo, setPhoto] = useState<File[]>([]);
  const [phone, setPhone] = useState<string>(user?.phone || "");

  const validation = Yup.object().shape({
    gender: Yup.string().required("Выберите пол"),
    firstName: Yup.string()
      .required("Заполните обязательное поле")
      .max(60, "Превышено макс. длина строки (60).")
      .min(2, "Минимальная длина строки 2"),
    secondName: Yup.string()
      .required("Заполните обязательное поле")
      .max(60, "Превышено макс. длина строки (60).")
      .min(2, "Минимальная длина строки 2"),
    lastName: Yup.string()
      .max(60, "Превышено макс. длина строки (60).")
      .min(2, "Минимальная длина строки 2"),
    dateBirth: Yup.string().required("Выберите дату рождения"),
    email: Yup.string()
      .required("Заполните обязательное поле")
      .email("Электронная почта недействительна"),
    phone: Yup.string().required("Заполните обязательное поле"),
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<IUserInfo>({
    resolver: yupResolver(validation),
  });

  const toggleEditClick = () => setIsEdit(!isEdit);
  const handleFileChange = (img: File[]) => setPhoto(img);
  const handlePhoneChange = (value: string) => setPhone(value);

  const onSubmit = (values: IUserInfo) => {};

  return (
    <React.Fragment>
      <TabPane tabId={1}>
        <Card>
          <CardBody>
            <h2>Личная информация</h2>
            <CustomDivider />
            <form
              className={"form-horizontal"}
              onSubmit={handleSubmit(onSubmit)}
            >
              <div className={"content-group"}>
                <span className={"text-muted fs-16"}>
                  Ваши персональные данные
                </span>
              </div>
              <Row className={"fs-14"} style={{ gap: "1em 0" }}>
                <Col lg={4}>
                  <label className={"col-lg-3 col-form-label w-100"}>Пол</label>
                </Col>
                <Col lg={8}>
                  <div className={"form-check form-check-inline"}>
                    <label className={"form-label"} htmlFor={"gender-male"}>
                      Мужской
                    </label>
                    <input
                      type={"radio"}
                      id={"gender-male"}
                      className={`form-check-input ${
                        errors.gender ? "is-invalid" : ""
                      }`}
                      defaultValue={"M"}
                      defaultChecked={user?.gender === "M"}
                      disabled={isEdit}
                      {...register("gender")}
                    />
                  </div>
                  <div className={"form-check form-check-inline"}>
                    <label className={"form-label"} htmlFor={"gender-female"}>
                      Женский
                    </label>
                    <input
                      type={"radio"}
                      id={"gender-female"}
                      className={`form-check-input ${
                        errors.gender ? "is-invalid" : ""
                      }`}
                      defaultValue={"F"}
                      defaultChecked={user?.gender === "F"}
                      disabled={isEdit}
                      {...register("gender")}
                    />
                  </div>
                  <div className={"form-check form-check-inline"}>
                    <label className={"form-label"} htmlFor={"gender-n"}>
                      Не указать
                    </label>
                    <input
                      type={"radio"}
                      id={"gender-n"}
                      className={`form-check-input ${
                        errors.gender ? "is-invalid" : ""
                      }`}
                      defaultValue={"N"}
                      defaultChecked={user?.gender === "N"}
                      disabled={isEdit}
                      {...register("gender")}
                    />
                  </div>
                  <FormFeedback
                    type={"invalid"}
                    className={errors.gender && "d-block"}
                  >
                    {errors.gender?.message}
                  </FormFeedback>
                </Col>
                <Col lg={4}>
                  <label
                    className={"col-lg-3 col-form-label w-100"}
                    htmlFor={"firstName"}
                  >
                    Фамилия
                  </label>
                </Col>
                <Col lg={8}>
                  <input
                    type={"text"}
                    id={"firstName"}
                    className={`form-control ${
                      errors.firstName ? "is-invalid" : ""
                    }`}
                    placeholder={"Введите вашу фамилию"}
                    defaultValue={user?.firstName || ""}
                    disabled={isEdit}
                    {...register("firstName")}
                  />
                  <FormFeedback type={"invalid"}>
                    {errors.firstName?.message}
                  </FormFeedback>
                </Col>
                <Col lg={4}>
                  <label
                    className={"col-lg-3 col-form-label w-100"}
                    htmlFor={"secondName"}
                  >
                    Имя
                  </label>
                </Col>
                <Col lg={8}>
                  <input
                    type={"text"}
                    name={"secondName"}
                    className={`form-control ${
                      errors.secondName ? "is-invalid" : ""
                    }`}
                    placeholder={"Введите ваше имя"}
                    defaultValue={user?.secondName || ""}
                    disabled={isEdit}
                    {...register("secondName")}
                  />
                  <FormFeedback type={"invalid"}>
                    {errors.secondName?.message}
                  </FormFeedback>
                </Col>
                <Col lg={4}>
                  <label
                    className={"col-lg-3 col-form-label w-100"}
                    htmlFor={"secondName"}
                  >
                    Отчество
                  </label>
                </Col>
                <Col lg={8}>
                  <input
                    type={"text"}
                    name={"lastName"}
                    id={"lastName"}
                    className={"form-control"}
                    placeholder={"Введите ваше отчество"}
                    defaultValue={user?.lastName || ""}
                    disabled={isEdit}
                    {...register("lastName")}
                  />
                </Col>
                <Col lg={4}>
                  <label
                    className={"form-label col-lg-3 col-form-label w-100"}
                    htmlFor={"dateBirth"}
                  >
                    Дата рождения
                  </label>
                </Col>
                <Col lg={8}>
                  <input
                    type={"date"}
                    id={"dateBirth"}
                    className={`form-control ${
                      errors.dateBirth ? "is-invalid" : ""
                    }`}
                    defaultValue={dateConverter(user?.dateBirth || "")}
                    disabled={isEdit}
                    {...register("dateBirth")}
                  />
                  <FormFeedback type={"invalid"}>
                    {errors.dateBirth?.message}
                  </FormFeedback>
                </Col>
                <Col lg={4}>
                  <label
                    className={"form-label col-lg-3 col-form-label w-100"}
                    htmlFor={"email"}
                  >
                    Почта
                  </label>
                </Col>
                <Col lg={8}>
                  <input
                    type={"email"}
                    id={"email"}
                    className={`form-control ${
                      errors.email ? "is-invalid" : ""
                    }`}
                    placeholder={"Введите адрес электронной почты"}
                    defaultValue={user?.email || ""}
                    disabled={isEdit && !user?.isConfirmedEmail}
                    {...register("email")}
                  />
                  <FormFeedback type={"invalid"}>
                    {errors.email?.message}
                  </FormFeedback>
                </Col>
                {!user?.isConfirmedEmail && (
                  <>
                    <Col lg={4}>Подтвердите почту</Col>
                    <Col lg={8}>
                      <Link
                        to={"/confirm-email"}
                        className={"text-decoration-underline"}
                      >
                        Подтвердить сейчас
                      </Link>
                    </Col>
                  </>
                )}
                <Col lg={4}>
                  <label
                    className={"form-label col-lg-3 col-form-label w-100"}
                    htmlFor={"phone"}
                  >
                    Телефон
                  </label>
                </Col>
                <Col lg={8}>
                  <PhoneInput
                    country={language?.name || "ru"}
                    value={`${user?.phone}`}
                    inputClass={"w-100"}
                    onChange={handlePhoneChange}
                    disabled={isEdit}
                  />
                  <FormFeedback type={"invalid"}>
                    {errors.phone?.message}
                  </FormFeedback>
                </Col>
                {!user?.isConfirmedPhone && (
                  <>
                    <Col lg={4}>Подтвердите телефон</Col>
                    <Col lg={8}>
                      <Link
                        to={"/confirm-phone"}
                        className={"text-decoration-underline"}
                      >
                        Подтвердить сейчас
                      </Link>
                    </Col>
                  </>
                )}
                {!isEdit && (
                  <>
                    <Col lg={4}>Фотография</Col>
                    <Col lg={8}>
                      <SingleImage
                        currentImage={user?.image || ""}
                        name={user?.email || ""}
                        onChange={handleFileChange}
                      />
                    </Col>
                  </>
                )}
                {!isEdit && (
                  <>
                    <Col lg={4}>
                      <label className={"form-label mb-0"}>Описание</label>
                    </Col>
                    <Col lg={8}>
                      <CKEditor
                        editor={ClassicEditor}
                        data={user?.description}
                        onCange={(event, editor) => {
                          console.log(event, editor);
                        }}
                        diabled={isEdit}
                        config={{
                          isReadOnly: isEdit,
                        }}
                      />
                    </Col>
                  </>
                )}
              </Row>
              <div
                className={"d-flex justify-content-end align-items-end mt-3"}
              >
                <Button
                  type={"button"}
                  className={"btn btn-outline-danger me-2"}
                  color={"transparent"}
                  onClick={toggleEditClick}
                >
                  {isEdit ? (
                    <>
                      <i className={"ri-edit-line"}></i> Изменить
                    </>
                  ) : (
                    <>
                      <i className={"ri-close-line"}></i> Отмена
                    </>
                  )}
                </Button>
                <Button
                  type={"submit"}
                  color={"success"}
                  disabled={!isEdit && isLoading}
                >
                  <i className={"ri-check-double-fill"}></i> Сохранить
                </Button>
              </div>
            </form>
          </CardBody>
        </Card>
      </TabPane>
    </React.Fragment>
  );
};

export default CustomerInfo;
