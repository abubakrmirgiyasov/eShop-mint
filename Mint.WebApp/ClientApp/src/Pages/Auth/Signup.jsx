import React, { useState } from "react";
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
} from "reactstrap";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import * as Yup from "yup";
import { useFormik } from "formik";

const Signup = () => {
  const [isPhotoSelected, setIsPhotoSelected] = useState("d-none");
  const [imageSource, setImageSource] = useState(null);

  const previewImage = (e) => {
    if (e.target.files.length) {
      var reader = new FileReader();
      reader.readAsDataURL(e.target.files[0]);

      reader.onload = function (e) {
        setImageSource(e.target.result);
        setIsPhotoSelected("");
      };
    } else {
      setIsPhotoSelected("d-none");
      setImageSource(null);
    }
  };

  const validation = useFormik({
    enableReinitialize: true,
    initialValues: {
      firstName: "",
      secondName: "",
      lastName: "",
      email: "",
      phone: "",
      password: "",
      description: "",
      gender: "",
      dateOfBirth: "",
      photo: null,
    },
    validationSchema: Yup.object({
      gender: Yup.string().required(""),
    }),
    onSubmit: (values) => {

    },
  });

  const handleSubmit = (e) => {
    const data = {
      firstName: "test3",
      secondName: "test4",
      lastName: null,
      email: "testw@m.com",
      phone: 89430923456,
      password: "1234",
      description: "testsdf slhuh nas.i3 lkjslfj ,nxmnvlksa; kjjedfmv xnzvtw",
      gender: "M",
      dateOfBirth: "2001-01-01",
      photo: {
        path: "tetdfgfd",
        extension: ".jpg",
        folder: "tesd",
        name: "123s",
      },
    };
    fetchWrapper.post("api/user/registration", data);
  };

  return (
    <div className="page-content">
      <Container>
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
                      invalid={
                        validation.touched.gender && validation.errors.gender 
                          ? true
                          : false
                      }
                    />
                    <label className="form-check-label" htmlFor="gender-female">
                      Женский
                    </label>
                  </div>
                  {validation.touched.gender && validation.errors.gender ? (
                  <FormFeedback type="invalid">
                    {validation.errors.gender}
                  </FormFeedback>
                ) : null}
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
                  />
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
                  />
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
                  />
                </Col>
                <Col lg={4}>
                  <label className="form-label">Дата рождения</label>
                </Col>
                <Col md={8} className="mb-3">
                  <div className="d-flex">
                    <Input
                      type="number"
                      className="form-control me-2"
                      name="day"
                      placeholder="День"
                    />
                    <Input
                      type="number"
                      className="form-control me-2"
                      name="month"
                      placeholder="Месяц"
                    />
                    <Input
                      type="number"
                      className="form-control"
                      name="year"
                      placeholder="Год"
                    />
                  </div>
                </Col>
                <Col lg={4}>
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
                  />
                </Col>
                <Col lg={4}>
                  <label className="form-label mt-3" htmlFor="tel">
                    Телефон
                  </label>
                </Col>
                <Col lg={8} className="mt-3 mb-3">
                  <Input
                    type="tel"
                    className="form-control"
                    name="tel"
                    id="tel"
                    placeholder="Введите телефон"
                    defaultValue={""}
                  />
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
                    name="photo"
                    onChange={previewImage}
                    defaultValue={""}
                  />
                  {
                    <div
                      className={`mt-3 d-flex justify-content-center align-items-center ${isPhotoSelected}`}
                      id="previewImage"
                    >
                      <img src={imageSource} width={100} height={100} />
                    </div>
                  }
                </Col>
              </Row>
              <div className="container">
                <Input type="checkbox" />
                <label className="text-muted fs-13">
                  Я, соглашаюсь там крч потом поменяю заебал
                </label>
              </div>
              <div className="d-flex justify-content-end align-items-end">
                <Button type="submit" className="btn btn-success">
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
