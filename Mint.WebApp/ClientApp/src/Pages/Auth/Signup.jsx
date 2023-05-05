import React, { useEffect, useState } from "react";
import {
  Button,
  Card,
  CardBody,
  Col,
  Container,
  Form,
  FormFeedback,
  Input,
  Row,
  Spinner,
} from "reactstrap";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import * as Yup from "yup";
import { useFormik } from "formik";
import { Error } from "../../components/Notification/Error";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";

const Signup = () => {
  const [isPhotoSelected, setIsPhotoSelected] = useState("d-none");
  const [imageSource, setImageSource] = useState(null);
  const [imageFile, setImageFile] = useState(null);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  const navigate = useNavigate();

  const { isLoggedIn: isLoggedIn } = useSelector((state) => state.Signin);

  const strongRegex =
    /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?_&])[A-Za-z\d@$!%*?&_]{6,20}$/;
  const phoneRegExp =
    /^((\\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/;

  const previewImage = (e) => {
    if (e.target.files.length) {
      setImageFile(e.target.files[0]);
      var reader = new FileReader();
      reader.readAsDataURL(e.target.files[0]);

      reader.onload = function (e) {
        setImageSource(e.target.result);
        setIsPhotoSelected("");
      };
    } else {
      setIsPhotoSelected("d-none");
      setImageSource(null);
      setImageFile(null);
    }
  };

  const validation = useFormik({
    enableReinitialize: true,
    initialValues: {
      gender: "N",
      firstName: "",
      secondName: "",
      lastName: "",
      email: "",
      phone: "",
      password: "",
      description: "",
      day: "",
      month: "",
      year: "",
      photo: null,
    },
    validationSchema: Yup.object({
      firstName: Yup.string().required("Заполните обязательное поле"),
      secondName: Yup.string().required("Заполните обязательное поле"),
      day: Yup.number()
        .min(1, "День обычно начинается с 1")
        .required("Заполните обязательное поле"),
      month: Yup.number().required("Заполните обязательное поле"),
      year: Yup.number().required("Заполните обязательное поле"),
      email: Yup.string()
        .email("Введите корректный E-mail")
        .required("Заполните обязательное поле"),
      password: Yup.string()
        .required("Заполните обязательное поле")
        .test("len", "Слишком короткый пароль", (val) => val.length >= 6)
        .matches(strongRegex, "Не надежный пароль ('Aa''_$@?''0-9')")
        .oneOf([Yup.ref("confirmPassword")], "Пароли не совпадают."),
      confirmPassword: Yup.string()
        .required("Заполните обязательное поле")
        .test("len", "Слишком короткый пароль", (val) => val.length >= 6)
        .matches(strongRegex, "Не надежный пароль (Newuser_2023)")
        .oneOf([Yup.ref("password")], "Пароли не совпадают."),
      phone: Yup.string()
        .min(10, "мин. 10 цифр")
        .max(11, "макс. 11 цифр")
        .matches(phoneRegExp, "Введите действительный номер")
        .required("Заполните обязательное поле"),
    }),
    onSubmit: (values) => {
      setIsLoading(true);

      let formData = new FormData();
      formData.append("firstName", values.firstName);
      formData.append("secondName", values.secondName);
      formData.append("lastName", values.lastName);
      formData.append("email", values.email);
      formData.append("phone", values.phone);
      formData.append("password", values.password);
      formData.append("gender", values.gender);
      formData.append(
        "dateOfBirth",
        `${values.day}.${values.month}.${values.year}`
      );
      formData.append("description", values.description);

      if (imageFile) {
        formData.append("folder", "user");
        formData.append("photo", imageFile);
      }

      fetchWrapper
        .post("api/user/registration", formData, false)
        .then((response) => {
          setIsLoading(false);
          navigate("/");
        })
        .catch((error) => {
          setError(error);
          setIsLoading(false);
        });
    },
  });

  useEffect(() => {
    if (isLoggedIn) {
      navigate("/");
    }
  }, [isLoggedIn]);

  document.title = "Регистрация - Mint";
  return (
    <div className="page-content">
      <Container>
        {!isLoading ? error ? <Error message={error} /> : null : null}
        <Card>
          <CardBody>
            <h1 className="mb-2">Регистрация</h1>
            <h4 className="text-muted mb-2 fs-14">ВАШИ ПЕРСОНАЛЬНЫЕ ДАННЫЕ</h4>
            <Form
              className="form-horizontal"
              onSubmit={(e) => {
                e.preventDefault();
                validation.handleSubmit();
                return false;
              }}
              encType="multipart/form-data"
            >
              <Row className="fs-16">
                <Col lg={4}>
                  <label className="col-lg-3 col-form-label w-100">Пол</label>
                </Col>
                <Col lg={8}>
                  <div className="form-check form-check-inline">
                    <Input
                      type="radio"
                      className="form-check-input"
                      defaultValue={"M"}
                      defaultChecked={""}
                      id="gender-male"
                      name="gender"
                      onChange={validation.handleChange}
                      onBlur={validation.handleBlur}
                    />
                    <label className="form-check-label" htmlFor="gender-male">
                      Мужской
                    </label>
                  </div>
                  <div className="form-check form-check-inline">
                    <Input
                      type="radio"
                      className="form-check-input"
                      defaultValue={"F"}
                      defaultChecked={""}
                      id="gender-female"
                      name="gender"
                      onChange={validation.handleChange}
                      onBlur={validation.handleBlur}
                    />
                    <label className="form-check-label" htmlFor="gender-female">
                      Женский
                    </label>
                  </div>
                  <div className="form-check form-check-inline">
                    <Input
                      type="radio"
                      className="form-check-input"
                      defaultValue={"N"}
                      defaultChecked={true}
                      id="gender-private"
                      name="gender"
                      onChange={validation.handleChange}
                      onBlur={validation.handleBlur}
                    />
                    <label
                      className="form-check-label"
                      htmlFor="gender-private"
                    >
                      Не указать
                    </label>
                  </div>
                </Col>
                <Col lg={4}>
                  <label
                    className="col-lg-3 col-form-label w-100"
                    htmlFor="firstName"
                  >
                    Фамилия
                  </label>
                </Col>
                <Col lg={8} className="mb-3">
                  <Input
                    type="text"
                    className="form-control"
                    defaultValue={""}
                    id="firstName"
                    name="firstName"
                    placeholder="Введите вашу фамилию"
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                    invalid={
                      validation.touched.firstName &&
                      validation.errors.firstName
                        ? true
                        : false
                    }
                  />
                  {validation.touched.firstName &&
                  validation.errors.firstName ? (
                    <FormFeedback type="invalid">
                      {validation.errors.firstName}
                    </FormFeedback>
                  ) : null}
                </Col>
                <Col lg={4}>
                  <label
                    className="col-lg-3 col-form-label"
                    htmlFor="secondName"
                  >
                    Имя
                  </label>
                </Col>
                <Col lg={8} className="mb-3">
                  <Input
                    type="text"
                    className="form-control"
                    defaultValue={""}
                    id="secondName"
                    name="secondName"
                    placeholder="Введите ваше имя"
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                    invalid={
                      validation.touched.secondName &&
                      validation.errors.secondName
                        ? true
                        : false
                    }
                  />
                  {validation.touched.secondName &&
                  validation.errors.secondName ? (
                    <FormFeedback type="invalid">
                      {validation.errors.secondName}
                    </FormFeedback>
                  ) : null}
                </Col>
                <Col lg={4}>
                  <label
                    className="col-lg-3 col-form-label w-100"
                    htmlFor="lastName"
                  >
                    Отчество
                  </label>
                </Col>
                <Col md={8} className="mb-3">
                  <Input
                    type="text"
                    className="form-control"
                    defaultValue={""}
                    id="lastName"
                    name="lastName"
                    placeholder="Введите ваше отчество"
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                  />
                </Col>
                <Col lg={4}>
                  <label className="form-label">Дата рождения</label>
                </Col>
                <Col md={8} className="mb-3">
                  <Row>
                    <Col lg={4}>
                      <Input
                        type="number"
                        className="form-control me-2"
                        name="day"
                        placeholder="День"
                        onChange={validation.handleChange}
                        onBlur={validation.handleBlur}
                        invalid={
                          validation.touched.day && validation.errors.day
                            ? true
                            : false
                        }
                      />
                      {validation.touched.day && validation.errors.day ? (
                        <FormFeedback type="invalid">
                          {validation.errors.day}
                        </FormFeedback>
                      ) : null}
                    </Col>
                    <Col lg={4}>
                      <Input
                        type="number"
                        className="form-control me-2"
                        name="month"
                        placeholder="Месяц"
                        onChange={validation.handleChange}
                        onBlur={validation.handleBlur}
                        invalid={
                          validation.touched.month && validation.errors.month
                            ? true
                            : false
                        }
                      />
                      {validation.touched.month && validation.errors.month ? (
                        <FormFeedback type="invalid">
                          {validation.errors.month}
                        </FormFeedback>
                      ) : null}
                    </Col>
                    <Col lg={4}>
                      <Input
                        type="number"
                        className="form-control"
                        name="year"
                        placeholder="Год"
                        onChange={validation.handleChange}
                        onBlur={validation.handleBlur}
                        invalid={
                          validation.touched.year && validation.errors.year
                            ? true
                            : false
                        }
                      />
                      {validation.touched.year && validation.errors.year ? (
                        <FormFeedback type="invalid">
                          {validation.errors.year}
                        </FormFeedback>
                      ) : null}
                    </Col>
                  </Row>
                </Col>
                <Col lg={4} className="mb-3">
                  <label className="form-label" htmlFor="email">
                    Почта
                  </label>
                </Col>
                <Col lg={8}>
                  <Input
                    type="email"
                    className="form-control"
                    name="email"
                    id="email"
                    placeholder="Введите адрес электроной почты"
                    defaultValue={""}
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                    invalid={
                      validation.touched.email && validation.errors.email
                        ? true
                        : false
                    }
                  />
                  {validation.touched.email && validation.errors.email ? (
                    <FormFeedback type="invalid">
                      {validation.errors.email}
                    </FormFeedback>
                  ) : null}
                </Col>
                <Col lg={4} className="mb-3">
                  <label className="form-label" htmlFor="password">
                    Пароль <span className="text-danger">*</span>
                  </label>
                </Col>
                <Col lg={8}>
                  <Input
                    type="password"
                    className="form-control"
                    name="password"
                    id="password"
                    placeholder="Введите пароль"
                    defaultValue={""}
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                    invalid={
                      validation.touched.password && validation.errors.password
                        ? true
                        : false
                    }
                  />
                  {validation.touched.email && validation.errors.password ? (
                    <FormFeedback type="invalid">
                      {validation.errors.password}
                    </FormFeedback>
                  ) : null}
                </Col>
                <Col lg={4} className="mb-3">
                  <label className="form-label" htmlFor="confirmPassword">
                    Повторите Пароль <span className="text-danger">*</span>
                  </label>
                </Col>
                <Col lg={8}>
                  <Input
                    type="password"
                    className="form-control"
                    id="confirmPassword"
                    placeholder="Введите пароль"
                    defaultValue={""}
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                    invalid={
                      validation.touched.password && validation.errors.password
                        ? true
                        : false
                    }
                  />
                  {validation.touched.email && validation.errors.password ? (
                    <FormFeedback type="invalid">
                      {validation.errors.password}
                    </FormFeedback>
                  ) : null}
                </Col>
                <Col lg={4}>
                  <label className="form-label" htmlFor="tel">
                    Телефон
                  </label>
                </Col>
                <Col lg={8}>
                  <Input
                    type="text"
                    className="form-control"
                    name="phone"
                    id="tel"
                    min={10}
                    max={11}
                    placeholder="Введите телефон"
                    defaultValue={""}
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                    invalid={
                      validation.touched.phone && validation.errors.phone
                        ? true
                        : false
                    }
                  />
                  {validation.touched.email && validation.errors.phone ? (
                    <FormFeedback type="invalid">
                      {validation.errors.phone}
                    </FormFeedback>
                  ) : null}
                </Col>
                <Col lg={4}>
                  <label className="form-label mt-3" htmlFor="photo">
                    Аватарка
                  </label>
                </Col>
                <Col lg={8} className="mt-3 mb-3">
                  <Input
                    type="file"
                    accept="image/png, image/jpeg, image/webp"
                    className="form-control me-2"
                    name="file"
                    onChange={(e) => {
                      previewImage(e);
                      validation.handleChange(e);
                    }}
                    onBlur={validation.handleBlur}
                    defaultValue={""}
                  />
                  {
                    <div
                      className={`mt-3 d-flex justify-content-center align-items-center ${isPhotoSelected}`}
                      id="previewImage"
                    >
                      <img
                        src={imageSource}
                        width={100}
                        height={100}
                        className="rounded-circle"
                      />
                    </div>
                  }
                </Col>
                <Col lg={4}>
                  <label className="form-label" htmlFor="description">
                    Описание
                  </label>
                </Col>
                <Col lg={8}>
                  <textarea
                    className="form-control"
                    id="description"
                    name="description"
                    placeholder="Описание"
                    onChange={validation.handleChange}
                    onBlur={validation.handleBlur}
                  ></textarea>
                </Col>
              </Row>
              <div className="container">
                <label className="text-muted fs-13">
                  <Input type="checkbox" className="me-1" />
                  Я, соглашаюсь там крч потом поменяю заебал
                </label>
              </div>
              <div className="d-flex justify-content-end align-items-end">
                <Button
                  type="submit"
                  className="btn btn-success"
                  disabled={isLoading}
                >
                  {isLoading ? (
                    <Spinner size={"sm"} className="me-2">
                      Loading...
                    </Spinner>
                  ) : null}
                  Зарегистрироваться
                </Button>
              </div>
            </Form>
          </CardBody>
        </Card>
      </Container>
    </div>
  );
};

export default Signup;
