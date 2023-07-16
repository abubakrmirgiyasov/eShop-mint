import React, { FC, useState } from "react";
import { Button, Col, Form, Modal, ModalBody, Row, Spinner } from "reactstrap";
import { signIn } from "../../store/authentication/authentication";
import { ISignIn } from "../../services/authentication/authService";
import { useDispatch } from "react-redux";
import { Link, useNavigate } from "react-router-dom";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import Request from "../../helpers/requestWrapper/request";
import Error from "../../pages/Errors/Error";
import * as Yup from "yup";
import { fetch } from "../../helpers/fetch";

// import MyInput from "../../components/Forms/Input";

// media
import LogoLight from "../../assets/images/logos/Logo256.png";

interface IAuth {
  isOpen: boolean;
  error: string;
  toggle: () => void;
}

const SignInModal: FC<IAuth> = ({ isOpen, error, toggle }) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const dispatch = useDispatch();
  const navigate = useNavigate();

  const schema = Yup.object({
    email: Yup.string()
      .required("Заполните обязательное поле")
      .email("Неверный адрес электронной почты"),
    password: Yup.string().required("Заполните обязательное поле"),
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<ISignIn>({
    resolver: yupResolver(schema),
  });

  const onSubmit = (values: ISignIn) => {
    console.log("values");
    dispatch(signIn(fetch(), values))
      .then(() => {
        navigate("/");
        setIsLoading(false);
        // window.location.reload();
      })
      .catch(() => setIsLoading(false));
  };

  return (
    <React.Fragment>
      {error ? <Error message={error} /> : null}
      <Modal isOpen={isOpen} toggle={toggle} centered={true}>
        <ModalBody>
          <div className="d-flex justify-content-center align-items-center w-100 h-50 mb-2">
            <img
              src={LogoLight}
              alt={"logo"}
              width={100}
              height={100}
              className={"logo-dark"}
              onClick={toggle}
            />
          </div>
          <Form onSubmit={handleSubmit(onSubmit)}>
            <Row>
              <Col lg={12} className={"mb-3"}>
                <input
                  type={"email"}
                  // name={"email"}
                  // id={"email"}
                  // // label={"Email"}
                  // placeholder={"Введите адрес электроной почты"}
                  // required={true}
                  // isError={!!errors.email}
                  // error={errors.email?.message}
                  className={`form-control ${errors.email ? "is-invalid" : ""}`}
                  {...register("email")}
                />
                <div className="invalid-feedback">{errors.email?.message}</div>
              </Col>
              <Col lg={12}>
                <input
                  type={"password"}
                  // name={"password"}
                  // id={"password"}
                  // label={"Пароль"}
                  // placeholder={"Введите Пароль"}
                  // required={true}
                  // isError={!!errors.password}
                  // error={errors.password?.message}
                  className={`form-control ${
                    errors.password ? "is-invalid" : ""
                  }`}
                  {...register("password")}
                />
                <div className="invalid-feedback">{errors.email?.message}</div>
              </Col>
              <Col className={"col-auto mb-3"}>
                <div className={"float-end"}>
                  <Link to={"/forgot-password"} className={"text-muted"}>
                    Забыли пароль?
                  </Link>
                </div>
              </Col>
              <Col
                lg={12}
                className={
                  "d-flex justify-content-center align-items-center mb-2"
                }
              >
                <Button
                  type={"submit"}
                  disabled={isLoading}
                  color={"success"}
                  className={"btn btn-success w-50"}
                >
                  {isLoading ? (
                    <Spinner size={"sm"} className={"me-2"} />
                  ) : (
                    <i className={"ri-login-circle-line"}></i>
                  )}{" "}
                  Войти
                </Button>
              </Col>
            </Row>
            <div className={"d-flex justify-content-center align-items-center"}>
              Еще нет аккаунта?&nbsp;
              <Link
                to={"/signup"}
                className={"fw-semibold text-primary text-decoration-underline"}
                onClick={toggle}
              >
                Регистрация
              </Link>
            </div>
          </Form>
        </ModalBody>
      </Modal>
    </React.Fragment>
  );
};

export default SignInModal;
