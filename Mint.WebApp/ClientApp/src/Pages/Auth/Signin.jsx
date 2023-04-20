import { useFormik } from "formik";
import React, { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Link } from "react-router-dom";
import {
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
import * as Yup from "yup";
import { signin } from "../../helpers/authentication";
import { Error } from "../../components/Notification/Error";

// images
import LogoLight from '../../assets/images/logo-mint-light.png';
import LogoDark from '../../assets/images/logo-mint-dark.png';

const Signin = (props) => {
  const dispatch = useDispatch();
  const [passwordShow, setPasswordShow] = useState(false);
  const [error, setError] = useState(null);
  const [isLoading, setIsLoading] = useState(false);

  const { Message: message } = useSelector(message => message);
  
  const validation = useFormik({
    enableReinitialize: true,
    initialValues: {
      email: "",
      password: "",
    },
    validationSchema: Yup.object({
      email: Yup.string().required("Заполните обязательное поле"),
      password: Yup.string().required("Заполните обязательное поле"),
    }),
    onSubmit: (values) => {
      setIsLoading(true);
      dispatch(signin(values))
        .then(() => {
          window.location.reload();
          setIsLoading(false);
        })
        .catch((error) => {
          setError(error);
          setIsLoading(false);
        });
    },
  });

  return (
    <React.Fragment>
      {!!isLoading ? message ? <Error message={message.message} /> : null : null}
      <Modal
        isOpen={props.isOpen}
        toggle={props.toggle}
        className="border-0"
        modalClassName="modal-xxl fade zoomIn"
      >
        <ModalHeader
          className="p-3 bg-soft-white border-bottom-dashed"
          toggle={props.toggle}
          style={{
            borderBottom: "1px",
          }}
        >
          Войти
        </ModalHeader>
        <ModalBody>
          <Form
            onSubmit={(e) => {
              e.preventDefault();
              validation.handleSubmit();
              return false;
            }}
            action="#"
          >
            <div className="d-flex justify-content-center align-items-center w-100 h-50 mb-2">
              {/* <img src={LogoLight} alt={"logo"} width={100} height={100} className="logo-light" /> */}
              <img src={LogoLight} alt={"logo"} width={100} height={100} className="logo-dark" />
            </div>
            <Row>
              <Col lg={12} className="mb-2">
                <Label className="form-label" htmlFor="email">
                  Email
                </Label>
                <Input
                  type="email"
                  id="email"
                  name="email"
                  className="form-control"
                  placeholder="Введите адрес электроной почты"
                  onChange={validation.handleChange}
                  onBlur={validation.handleBlur}
                  defaultValue={validation.values.email || ""}
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
              <Col lg={12} className="mb-2">
                <div className="mb-3">
                  <Label htmlFor="password" className="form-label">
                    Пароль
                  </Label>
                  <div className="position-relative auth-pass-inputgroup mb-3">
                    <Input
                      type={passwordShow ? "text" : "password"}
                      name="password"
                      id="password"
                      className="form-control pe-5"
                      placeholder="Введите Пароль"
                      onChange={validation.handleChange}
                      onBlur={validation.handleBlur}
                      invalid={
                        validation.touched.password &&
                        validation.errors.password
                          ? true
                          : false
                      }
                    />
                    {validation.touched.password &&
                    validation.errors.password ? (
                      <FormFeedback type="invalid">
                        {validation.errors.password}
                      </FormFeedback>
                    ) : null}
                    <button
                      type="button"
                      className="btn btn-link position-absolute end-0 top-0 text-decoration-none text-muted"
                      id="password-addon"
                      onClick={() => setPasswordShow(!passwordShow)}
                    >
                      {validation.errors.password ? (
                        ""
                      ) : (
                        <i className="ri-eye-fill align-middle"></i>
                      )}
                    </button>
                  </div>
                </div>
                <div className="mb-3">
                  <div className="float-end">
                    <Link to="/forgot-password" className="text-muted">
                      Забыли пароль?
                    </Link>
                  </div>
                </div>
              </Col>
            </Row>
            <div className="d-flex justify-content-center align-items-center mb-2">
              <button 
                type="submit" 
                color="success" 
                className="btn btn-success w-50"
                disabled={isLoading}
              >
                {isLoading ? (
                  <Spinner size={"sm"} className="me-2">
                    Loading...
                  </Spinner>
                ) : null}
                <i className="ri-login-box-line"></i>&nbsp;Войти
              </button>
            </div>
          </Form>
          <div className="d-flex justify-content-center align-items-center">
            Еще нет аккаунта?&nbsp;
            <Link
              to="/signup"
              className="fw-semibold text-primary text-decoration-underline"
              onClick={() => props.toggle()}
            >
              Регистрация
            </Link>
          </div>
        </ModalBody>
      </Modal>
    </React.Fragment>
  );
};

export default Signin;
