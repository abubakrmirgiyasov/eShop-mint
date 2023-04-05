import React, { useState } from "react";
import { Link } from "react-router-dom";
import {
  Col,
  Form,
  Input,
  Label,
  Modal,
  ModalBody,
  ModalHeader,
  Row,
} from "reactstrap";

const Signin = (props) => {
  const [passwordShow, setPasswordShow] = useState(false);

  return (
    <React.Fragment>
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
          <Form>
            <div className="d-flex justify-content-center align-items-center w-100 h-50 mb-2">
              <img src="../" width={100} height={100} />
            </div>
            <Row>
              <Col lg={12} className="mb-2">
                <Label className="form-label" htmlFor="email">
                  Email
                </Label>
                <Input
                  type="text"
                  id="email"
                  name="email"
                  className="form-control"
                  placeholder="Введите адрес электроной почты"
                />
              </Col>
              <Col lg={12} className="mb-2">
                <div className="mb-3">
                  <div className="float-end">
                    <Link to="/forgot-password" className="text-muted">
                      Забыли пароль?
                    </Link>
                  </div>
                </div>
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
                    />
                    <button
                      type="button"
                      className="btn btn-link position-absolute end-0 top-0 text-decoration-none text-muted"
                      id="password-addon"
                    //   onClick={() => setPasswordShow(!passwordShow)}
                    >
                        <i className="ri-eye-fill align-middle"></i>
                      {/* {validation.errors.password ? (
                        ""
                      ) : (
                        <i className="ri-eye-fill align-middle"></i>
                      )} */}
                    </button>
                  </div>
                </div>
              </Col>
            </Row>
            <div className="d-flex justify-content-center align-items-center mb-2">
              <button type="submit" className="btn btn-success w-50">
                <i className="ri-login-box-line"></i>&nbsp;Войти
              </button>
            </div>
          </Form>
          <div className="d-flex justify-content-center align-items-center">
            Еще нет аккаунта?&nbsp;
            <Link
              to="/signup"
              className="fw-semibold text-primary text-decoration-underline"
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
