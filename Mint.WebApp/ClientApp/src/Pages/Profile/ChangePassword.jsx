import React, { useState } from "react";
import {
  Button,
  Card,
  CardBody,
  Col,
  Form,
  FormFeedback,
  Input,
  Label,
  Row,
  Spinner,
  TabPane,
} from "reactstrap";
import * as Yup from "yup";
import { Error } from "../../components/Notification/Error";
import { Success } from "../../components/Notification/Success";
import { useFormik } from "formik";
import { fetchWrapper } from "../../helpers/fetchWrapper";


const ChangePassword = ({ userId }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(null);

  const strongRegex =
    /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?_&])[A-Za-z\d@$!%*?&_]{6,20}$/;

  const validation = useFormik({
    enableReinitialize: true,
    initialValues: {
      oldPassword: "",
      newPassword: "",
      confirmPassword: "",
    },
    validationSchema: Yup.object({
      oldPassword: Yup.string().required("Заполните обязательное поле"),
      newPassword: Yup.string()
        .required("Заполните обязательное поле")
        .test("len", "Слишком короткый пароль", (val) => val.length >= 6)
        .matches(strongRegex, "Не надежный пароль ('Aa''_$@?''0-9')")
        .oneOf([Yup.ref("confirmPassword")], "Пароли не совпадают."),
      confirmPassword: Yup.string()
        .required("Заполните обязательное поле")
        .test("len", "Слишком короткый пароль", (val) => val.length >= 6)
        .matches(strongRegex, "Не надежный пароль (Newuser_2023)")
        .oneOf([Yup.ref("newPassword")], "Пароли не совпадают."),
    }),
    onSubmit: (values, { resetForm }) => {
      setIsLoading(true);
      
      const data = {
        id: userId,
        oldPassword: values.oldPassword,
        newPassword: values.newPassword,
      };

      fetchWrapper
        .put("api/user/updateuserpassword", data)
        .then((response) => {
            resetForm();
            setIsLoading(false);
            setSuccess(response);
        })
        .catch((error) => {
            setError(error);
            setIsLoading(false);
        });
    },
  });

  return (
    <React.Fragment>
      <TabPane tabId={4}>
        {!isLoading ? error ? <Error message={error} /> : null : null}
        {!isLoading ? <Success message={success?.message} /> : null}
        <Card>
          <CardBody>
            <h2 className="mb-4">Изменить пароль</h2>
            <Form
              className="form-horizontal"
              onSubmit={(e) => {
                e.preventDefault();
                validation.handleSubmit(e);
                return false;
              }}
            >
              <Row>
                <Col lg={12} className="mb-3">
                  <div className="form-group">
                    <Label className="form-label" htmlFor="oldPassword">
                      Старый пароль
                    </Label>
                    <Input
                      type="password"
                      className="form-control"
                      id="oldPassword"
                      name="oldPassword"
                      placeholder="Введите старый пароль"
                      defaultValue={""}
                      onChange={validation.handleChange}
                      onBlur={validation.handleBlur}
                      invalid={
                        validation.touched.oldPassword &&
                        validation.errors.oldPassword
                          ? true
                          : false
                      }
                    />
                    {validation.touched.oldPassword &&
                    validation.errors.oldPassword ? (
                      <FormFeedback type="invalid">
                        {validation.errors.oldPassword}
                      </FormFeedback>
                    ) : null}
                  </div>
                </Col>
                <Col lg={12} className="mb-3">
                  <div className="form-group">
                    <Label className="form-label" htmlFor="newPassword">
                      Новый пароль
                    </Label>
                    <Input
                      type="password"
                      className="form-control"
                      id="newPassword"
                      name="newPassword"
                      placeholder="Введите новый пароль"
                      defaultValue={""}
                      onChange={validation.handleChange}
                      onBlur={validation.handleBlur}
                      invalid={
                        validation.touched.newPassword &&
                        validation.errors.newPassword
                          ? true
                          : false
                      }
                    />
                    {validation.touched.newPassword &&
                    validation.errors.newPassword ? (
                      <FormFeedback type="invalid">
                        {validation.errors.newPassword}
                      </FormFeedback>
                    ) : null}
                  </div>
                </Col>
                <Col lg={12} className="mb-3">
                  <div className="form-group">
                    <Label className="form-label" htmlFor="confirmPassword">
                      Повторите пароль
                    </Label>
                    <Input
                      type="password"
                      className="form-control"
                      id="confirmPassword"
                      placeholder="Повторите новый пароль"
                      defaultValue={""}
                      onChange={validation.handleChange}
                      onBlur={validation.handleBlur}
                      invalid={
                        validation.touched.confirmPassword &&
                        validation.errors.confirmPassword
                          ? true
                          : false
                      }
                    />
                    {validation.touched.confirmPassword &&
                    validation.errors.confirmPassword ? (
                      <FormFeedback type="invalid">
                        {validation.errors.confirmPassword}
                      </FormFeedback>
                    ) : null}
                  </div>
                </Col>
                <Col className="d-flex justify-content-end align-items-end">
                  <Button type="submit" color="success" disabled={isLoading}>
                    {isLoading ? (
                      <Spinner size={"sm"} className="me-2">
                        Loading...
                      </Spinner>
                    ) : null}
                    <i className="ri-edit-line"></i> Обновить пароль
                  </Button>
                </Col>
              </Row>
            </Form>
          </CardBody>
        </Card>
      </TabPane>
    </React.Fragment>
  );
};

export default ChangePassword;
