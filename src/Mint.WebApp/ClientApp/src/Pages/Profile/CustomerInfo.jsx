import React, { useEffect, useState } from "react";
import {
  Button,
  Card,
  CardBody,
  Col,
  Form,
  Input,
  Row,
  TabPane,
} from "reactstrap";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { Error } from "../../components/Notification/Error";
import PreviewSingleImage from "../../Admin/components/Dropzone/PreviewSingleImage";

const CustomerInfo = ({ userId, userImage }) => {
  const [isLoading, setIsLoading] = useState(true);
  const [userData, setUserData] = useState([]);
  const [error, setError] = useState(null);
  const [isEdit, setIsEdit] = useState(true);
  const [imageSource, setImageSource] = useState(null);

  useEffect(() => {
    fetchWrapper
      .get("api/user/getuserbyid/" + userId)
      .then((response) => {
        setIsLoading(false);
        setUserData(response);
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  }, [userId]);

  function handleFileChange(img) {
    setImageSource(img);
  }

  const handleSubmit = (e) => {
    let formData = new FormData();
    formData.append("id", userId);
    formData.append("gender", e.target.gender.value);
    formData.append("firstName", e.target.firstName.value);
    formData.append("secondName", e.target.secondName.value);
    formData.append("lastName", e.target.lastName.value);
    formData.append(
      "dateOfBirth",
      `${e.target.day.value}.${e.target.month.value}.${e.target.year.value}`
    );
    formData.append("description", e.target.description.value);

    if (imageSource) {
      formData.append("folder", "user");
      formData.append("photo", imageSource[0]);
    }

    fetchWrapper
      .put("api/user/updateuserinfo", formData, false)
      .then((response) => {
        const user = JSON.parse(localStorage.getItem("auth_user"));
        user.firstName = response.firstName;
        user.secondName = response.secondName;
        user.imagePath = response.imagePath;
        localStorage.setItem("auth_user", JSON.stringify(user));
        setIsLoading(false);
        window.location.reload();
      })
      .catch((error) => {
        setError(error);
        setIsLoading(false);
      });
  };

  return (
    <React.Fragment>
      <TabPane tabId={1}>
        {isLoading ? (
          <div className="d-flex justify-content-center align-items-center">
            <div className="spinner text-success" role="status">
              <span className="visually-hidden">Loading...</span>
            </div>
          </div>
        ) : (
          <Card>
            {error ? <Error message={error} /> : null}
            <CardBody>
              <h2>Информация о клиенте</h2>
              <Form
                className="form-horizontal"
                onSubmit={(e) => {
                  e.preventDefault();
                  handleSubmit(e);
                  return false;
                }}
              >
                <div className="content-group">
                  <span className="text-muted fs-16">
                    Ваши персональные данные
                  </span>
                </div>
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
                        defaultChecked={userData.gender === "M"}
                        id="gender-male"
                        name="gender"
                        disabled={isEdit}
                        required={true}
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
                        defaultChecked={userData.gender === "F"}
                        id="gender-female"
                        name="gender"
                        disabled={isEdit}
                        required={true} // required={userData.gender === "F" || userData.gender === "M"}
                      />
                      <label
                        className="form-check-label"
                        htmlFor="gender-female"
                      >
                        Женский
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
                      defaultValue={userData.firstName}
                      id="firstName"
                      name="firstName"
                      placeholder="Введите вашу фамилию"
                      disabled={isEdit}
                      required={true}
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
                      defaultValue={userData.secondName}
                      id="secondName"
                      name="secondName"
                      placeholder="Введите ваше имя"
                      disabled={isEdit}
                      required={true}
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
                      defaultValue={userData.lastName}
                      id="lastName"
                      name="lastName"
                      placeholder="Введите ваше отчество"
                      disabled={isEdit}
                    />
                  </Col>
                  <Col lg={4}>
                    <label className="form-label">Дата рождения</label>
                  </Col>
                  <Col md={8}>
                    <div className="d-flex">
                      <Input
                        type="number"
                        className="form-control me-2 mb-3"
                        name="day"
                        placeholder="День"
                        defaultValue={new Date(userData.dateBirth).getDate()}
                        disabled={isEdit}
                        required={true}
                      />
                      <Input
                        type="number"
                        className="form-control me-2 mb-3"
                        name="month"
                        placeholder="Месяц"
                        defaultValue={
                          new Date(userData.dateBirth).getMonth() + 1
                        }
                        disabled={isEdit}
                        required={true}
                      />
                      <Input
                        type="number"
                        className="form-control mb-3"
                        name="year"
                        placeholder="Год"
                        defaultValue={new Date(
                          userData.dateBirth
                        ).getFullYear()}
                        disabled={isEdit}
                        required={true}
                      />
                    </div>
                  </Col>
                  <Col lg={4}>
                    <label className="form-label">Почта</label>
                  </Col>
                  <Col lg={8}>
                    <Input
                      type="email"
                      className="form-control me-2 mb-3"
                      name="email"
                      placeholder="Введите адрес электроной почты"
                      defaultValue={userData.email}
                      disabled={true} // userData.isConfirmedEmail
                      required={true}
                    />
                  </Col>
                  {!userData.isConfirmedEmail ? (
                    <Col className="mb-3" lg={12}>
                      Подтвердите почту{" "}
                    </Col>
                  ) : null}
                  <Col lg={4}>
                    <label className="form-label">Телефон</label>
                  </Col>
                  <Col lg={8} className="mb-3">
                    <Input
                      type="tel"
                      className="form-control me-2"
                      name="tel"
                      placeholder="Введите телефон"
                      defaultValue={userData.phone}
                      disabled={true}
                      required={true}
                    />
                  </Col>
                  {!isEdit ? (
                    <>
                      <Col lg={4}>
                        <label className="form-label">Аватарка</label>
                      </Col>
                      <Col lg={8} className="mb-3">
                        <PreviewSingleImage
                          setSelectedImage={handleFileChange}
                          image={userImage}
                          name={"previewImage"}
                        />
                      </Col>
                    </>
                  ) : null}
                  <Col lg={4}>
                    <label className="form-label">Описание</label>
                  </Col>
                  <Col lg={8} className="mb-3">
                    <textarea
                      className="form-control me-2"
                      name="description"
                      placeholder="Описание"
                      disabled={isEdit}
                      defaultValue={userData.description}
                    ></textarea>
                  </Col>
                </Row>
                <div className="d-flex justify-content-end align-items-end">
                  <Button
                    type="button"
                    className="btn btn-outline-danger me-2"
                    color="transparent"
                    onClick={() => setIsEdit(!isEdit)}
                  >
                    {isEdit ? (
                      <>
                        <i className="ri-edit-line"></i> Изменить
                      </>
                    ) : (
                      <>
                        <i className="ri-close-line"></i> Отмена
                      </>
                    )}
                  </Button>
                  <Button
                    type="submit"
                    className="btn btn-success"
                    disabled={isEdit}
                  >
                    <i className="ri-check-double-fill"></i> Сохранить
                  </Button>
                </div>
              </Form>
            </CardBody>
          </Card>
        )}
      </TabPane>
    </React.Fragment>
  );
};

export default CustomerInfo;
