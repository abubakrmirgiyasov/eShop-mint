import React, { FC, FormEvent, useState } from "react";
import {
  Button,
  Col,
  FormFeedback,
  Modal,
  ModalBody,
  ModalHeader,
  Nav,
  NavItem,
  NavLink,
  Row,
  Spinner,
  TabContent,
  TabPane,
} from "reactstrap";
import PhoneInput from "react-phone-input-2";
import { ILanguage } from "../../services/types/ICommon";
import { useSelector } from "react-redux";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import * as Yup from "yup";
import { fetch } from "../../helpers/fetch";
import { Link } from "react-router-dom";
import SignInModal from "./SignInModal";

interface ISignUp {
  isOpen: boolean;
  toggle: () => void;
}

interface ISignUpWithEmail {
  email: string;
}

const SignUpModal: FC<ISignUp> = ({ isOpen, toggle }) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [activeTab, setActiveTab] = useState<number>(1);
  const [phone, setPhone] = useState<string>("");
  const [isPhoneError, setIsPhoneError] = useState<boolean>(false);

  const [codeWindow, setCodeWindow] = useState<boolean>(false);

  const customStyle = {
    borderColor: "#f06548",
    paddingRight: "calc(1.5em + 1rem)",
    backgroundImage:
      "url(data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 12 12' width='12' height='12' fill='none' stroke='%23f06548'%3e%3ccircle cx='6' cy='6' r='4.5'/%3e%3cpath stroke-linejoin='round' d='M5.8 3.6h.4L6 6.5z'/%3e%3ccircle cx='6' cy='8.2' r='.6' fill='%23f06548' stroke='none'/%3e%3c/svg%3e)",
    backgroundRepeat: "no-repeat",
    backgroundPosition: "right calc(0.375em + 0.25rem) center",
    backgroundSize: "calc(0.75em + 0.5rem) calc(0.75em + 0.5rem)",
  };

  const { language }: { language: ILanguage } = useSelector((state) => ({
    language: state.Language,
  }));

  const tabChangeToggle = (tab: number) => {
    if (activeTab !== tab) setActiveTab(tab);
  };

  const toggleSignInModal = () => {
    setCodeWindow(true);
  };

  const handlePhoneChange = (e: string) => {
    setPhone(e);
  };

  const handlePhoneSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    setIsPhoneError(!phone);
  };

  const onEmailSubmit = (e: ISignUpWithEmail) => {
    console.log(e);
    setIsLoading(true);

    fetch()
      .post("/user/sendemailconfirmationcode", e)
      .then((response) => {
        setIsLoading(false);
      })
      .catch((error) => {
        setIsLoading(false);
      });
  };

  const validateEmail = Yup.object().shape({
    email: Yup.string().required("Заполните обязательное поле"),
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<ISignUpWithEmail>({
    resolver: yupResolver(validateEmail),
  });

  return (
    <React.Fragment>
      <Modal isOpen={isOpen} toggle={toggle} centered={true}>
        <ModalHeader>Регистрация</ModalHeader>
        <ModalBody>
          <Nav tabs={true}>
            <NavItem>
              <NavLink
                className={activeTab === 1 ? "active" : ""}
                onClick={() => tabChangeToggle(1)}
                href={"#"}
              >
                По номеру телефона
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink
                className={activeTab === 2 ? "active" : ""}
                onClick={() => tabChangeToggle(2)}
                href={"#"}
              >
                По email
              </NavLink>
            </NavItem>
          </Nav>
          <TabContent activeTab={activeTab}>
            <TabPane tabId={1}>
              <form onSubmit={handlePhoneSubmit}>
                <Row>
                  <Col lg={12} className={"mt-3 mb-3"}>
                    <label htmlFor={"phone"}>Номер телефона</label>
                    <PhoneInput
                      country={language?.name || "ru"}
                      value={""}
                      inputClass={`${isPhoneError ? "is-invalid" : ""} w-100`}
                      onChange={handlePhoneChange}
                      inputStyle={isPhoneError ? customStyle : {}}
                    />
                    {isPhoneError && (
                      <FormFeedback
                        type={"invalid"}
                        className={`${isPhoneError ? "d-block" : ""}`}
                      >
                        {"Заполните обязательное поле"}
                      </FormFeedback>
                    )}
                  </Col>
                </Row>
                <div
                  className={"d-flex justify-content-end align-items-end mt-3"}
                >
                  <Button
                    type={"submit"}
                    color={"success"}
                    disabled={isLoading}
                  >
                    {isLoading ? (
                      <Spinner size={"sm"} className={"me-2"}>
                        Loading...
                      </Spinner>
                    ) : (
                      <i className={"ri-login-circle-line"}></i>
                    )}{" "}
                    Регистрация
                  </Button>
                </div>
              </form>
            </TabPane>
            <TabPane tabId={2}>
              <form onSubmit={handleSubmit(onEmailSubmit)}>
                <Row>
                  <Col lg={12} className={"mt-3 mb-3"}>
                    <label className={"form-label"} htmlFor={"email"}>
                      Адрес электроной почты
                    </label>
                    <div className={"form-icon right"}>
                      <input
                        type={"email"}
                        className={`form-control form-control-icon ${
                          errors.email ? "is-invalid" : ""
                        }`}
                        id={"email"}
                        placeholder={"Введите адрес электроной почты"}
                        {...register("email")}
                      />
                      {!errors.email && (
                        <i className={"ri-mail-unread-line"}></i>
                      )}
                      <FormFeedback type={"invalid"}>
                        {errors.email?.message}
                      </FormFeedback>
                    </div>
                  </Col>
                </Row>
                <div
                  className={"d-flex justify-content-end align-items-end mt-3"}
                >
                  <Button
                    type={"submit"}
                    color={"success"}
                    disabled={isLoading}
                  >
                    {isLoading ? (
                      <Spinner size={"sm"} className={"me-2"}>
                        Loading...
                      </Spinner>
                    ) : (
                      <i className={"ri-login-circle-line"}></i>
                    )}{" "}
                    Регистрация
                  </Button>
                </div>
              </form>
            </TabPane>
          </TabContent>
          <div className={"d-flex justify-content-center align-items-center"}>
            <Link
              color={"primary"}
              to={"#"}
              className={"text-decoration-underline"}
              onClick={() => {}}
            >
              Войти
            </Link>
          </div>
        </ModalBody>
      </Modal>
      <SignInModal isOpen={codeWindow} toggle={toggleSignInModal} />
    </React.Fragment>
  );
};

export default SignUpModal;
