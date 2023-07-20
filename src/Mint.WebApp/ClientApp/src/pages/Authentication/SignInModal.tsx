import React, { FC, FormEvent, useState } from "react";
import { Button, Col, Form, Modal, ModalBody, Row, Spinner } from "reactstrap";
import { signIn } from "../../store/authentication/authentication";
import { useDispatch } from "react-redux";
import { Link, useNavigate } from "react-router-dom";
import { fetch } from "../../helpers/fetch";

// media
import LogoLight from "../../assets/images/logos/Logo256.png";
import MyInput from "../../components/Forms/Input";

interface IAuth {
  isOpen: boolean;
  toggle: () => void;
}

const SignInModal: FC<IAuth> = ({ isOpen, toggle }) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const dispatch = useDispatch();
  const navigate = useNavigate();

  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [error, setError] = useState<string>("");

  const regex = new RegExp(/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i);

  const onSubmit = (e: FormEvent<Form>) => {
    e.preventDefault();

    if (regex.test(email) && password) {
      setIsLoading(true);
      const values = {
        email,
        password,
      };
      dispatch(signIn(fetch(), values))
        .then(() => {
          navigate("/");
          setIsLoading(false);
          // window.location.reload();
        })
        .catch(() => setIsLoading(false));
    } else if (!regex.test(email)) {
      setError("Неверный адрес электронной почты");
    } else if (!password) {
      setError("Заполните обязательное поле");
    }

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
          <Form onSubmit={onSubmit}>
            <Row>
              <Col lg={12} className={"mb-3"}>
                <MyInput
                  id={"email"}
                  type={"email"}
                  name={"email"}
                  required={true}
                  hasLabel={true}
                  label={"Адрес электроной почты"}
                  onChange={setEmail}
                  onBlur={setEmail}
                  isError={!email}
                  error={error}
                  placeholder={"Введите адрес электроной почты"}
                />
              </Col>
              <Col lg={12}>
                <MyInput
                  id={"password"}
                  type={"password"}
                  name={"password"}
                  required={true}
                  hasLabel={true}
                  label={"Пароль"}
                  onChange={setPassword}
                  onBlur={setPassword}
                  isError={!password}
                  error={error}
                  placeholder={"Введите пароль"}
                />
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
