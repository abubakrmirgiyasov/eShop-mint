import React, { FC, useState } from "react";
import {
  Button,
  Col,
  FormFeedback,
  Modal,
  ModalBody,
  Row,
  Spinner,
} from "reactstrap";
import { signIn } from "../../store/authentication/authentication";
import { useDispatch } from "react-redux";
import { Link, useNavigate } from "react-router-dom";
import { fetch } from "../../helpers/fetch";
import * as Yup from "yup";
import { useForm } from "react-hook-form";
import { ISignIn } from "../../services/authentication/authService";
import { yupResolver } from "@hookform/resolvers/yup";

// media
import LogoLight from "../../assets/images/logos/Logo256.png";

interface IAuth {
  isOpen: boolean;
  toggle: () => void;
}

const SignInModal: FC<IAuth> = ({ isOpen, toggle }) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const dispatch = useDispatch();
  const navigate = useNavigate();

  const validation = Yup.object().shape({
    email: Yup.string()
      .required("Заполните обязательное поле")
      .email("Электронная почта недействительна"),
    password: Yup.string().required("Заполните обязательное поле"),
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<ISignIn>({
    resolver: yupResolver(validation),
  });

  const onSubmit = (values: ISignIn) => {
    setIsLoading(true);

    dispatch(signIn(fetch(), values))
      .then(() => {
        navigate("/");
        setIsLoading(false);
        // window.location.reload();
      })
      .catch(() => setIsLoading(false));
    return false;
  };

  return (
    <React.Fragment>
      <Modal isOpen={isOpen} toggle={toggle} centered={true}>
        <ModalBody>
          <div className="d-flex justify-content-center align-items-center w-100 h-50 mb-2">
            <img
              src={LogoLight}
              alt={"logo"}
              width={100}
              height={100}
              className={"logo-dark mb-3"}
              onClick={toggle}
            />
          </div>
          <form onSubmit={handleSubmit(onSubmit)}>
            <Row>
              <Col lg={12} className={"mb-3"}>
                <label htmlFor={"email"}>Адрес электронной почты</label>
                <input
                  id={"email"}
                  type={"email"}
                  className={`form-control ${errors.email ? "is-invalid" : ""}`}
                  placeholder={"Введите адрес электроной почты"}
                  {...register("email")}
                />
                <FormFeedback type={"invalid"}>
                  {errors.email?.message}
                </FormFeedback>
              </Col>
              <Col lg={12}>
                <label htmlFor={"password"}>Пароль</label>
                <input
                  id={"password"}
                  type={"password"}
                  className={`form-control ${
                    errors.password ? "is-invalid" : ""
                  }`}
                  placeholder={"Введите пароль"}
                  {...register("password")}
                />
                <FormFeedback type={"invalid"}>
                  {errors.password?.message}
                </FormFeedback>
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
          </form>
        </ModalBody>
      </Modal>
    </React.Fragment>
  );
};

export default SignInModal;
