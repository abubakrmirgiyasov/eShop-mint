import React, {FC, useState} from "react";
import {Card, CardBody, Col, Container, FormFeedback, Row, Spinner} from "reactstrap";
import Notification from "../../components/Notifications/Notification";
import {Colors} from "../../constants/commonList";
import * as Yup from "yup";
import {useForm} from "react-hook-form";
import {yupResolver} from "@hookform/resolvers/yup";
import {ISignIn} from "../../types/Authentication/ISignIn";

// static files
import logo from "../../assets/images/logos/logo.png";

const SignUpPage: FC = () => {
    document.title = "Добро пожаловать. Авторизуйтесь чтобы продолжить - Mint";

    const [isLoading, setIsLoading] = useState<boolean>(false);

    const validation = Yup.object().shape({
        email: Yup.string()
            .required("Заполните обязательное поле")
            .email("Введите действительный адрес электронной почты")
            .matches(/^(?!.*@[^,]*,)/),
        password: Yup.string().required("Заполните обязательное поле"),
    });

    const {
        register,
        handleSubmit,
        formState: {errors},
    } = useForm<ISignIn>({
        resolver: yupResolver(validation)
    });

    const onSubmit = (values: ISignIn) => {

    };

    return (
        <div className={"auth-page-content"}>
            <Container>
                <Row>
                    <Col lg={12}>
                        <div className={"text-center mt-sm-5 mb-4 text-white-50"}>
                            <div>
                                <a href={"/"} className={"d-inline-block auth-logo"}>
                                    <img src={logo} alt={"logo mint"} height={50}/>
                                </a>
                            </div>
                            <p className={"mt-3 fs-15 fw-medium"}>
                                Mint Admin & Dashboard Template
                            </p>
                        </div>
                    </Col>
                </Row>
                <Row className={"justify-content-center"}>
                    <Col md={8} lg={6} xl={5}>
                        <Card className={"mt-4"}>
                            <CardBody className={"p-4"}>
                                <div className={"text-center mt-2"}>
                                    <h5 className={"text-primary"}>Добро Пожаловать!</h5>
                                    <p className={"text-muted"}>Войдите чтобы продолжить.</p>
                                </div>
                                <div className={"p-2 mt-4"}>
                                    <form onSubmit={handleSubmit(onSubmit)}>
                                        <div className={"mb-3"}>
                                            <label className={"form-label"} htmlFor={"email"}>
                                                Email или Телефон
                                            </label>
                                            <input
                                                type={"text"}
                                                id={"email"}
                                                className={`form-control ${
                                                    errors.email ? "is-invalid" : ""
                                                }`}
                                                placeholder={"Введите email или телефон"}
                                                {...register("email")}
                                            />
                                            <FormFeedback type={"invalid"}>
                                                {errors.email?.message}
                                            </FormFeedback>
                                        </div>
                                        <div className={"mb-3"}>
                                            <label className={"form-label"} htmlFor={"password"}>
                                                Пароль
                                            </label>
                                            <input
                                                type={"password"}
                                                id={"password"}
                                                className={`form-control ${
                                                    errors.password ? "is-invalid" : ""
                                                }`}
                                                placeholder={"Введите пароль"}
                                                {...register("password")}
                                            />
                                            <FormFeedback type={"invalid"}>
                                                {errors.password?.message}
                                            </FormFeedback>
                                        </div>
                                        <div className={"d-flex justify-content-center align-items-center"}>
                                            <button
                                                type={"submit"}
                                                disabled={isLoading}
                                                className={"btn btn-success"}>
                                                {isLoading ? (
                                                    <Spinner size={"sm"} className={"me-2"}>
                                                        Loading...
                                                    </Spinner>
                                                ) : (
                                                    <i className={"ri-login-circle-line me-2"}></i>
                                                )}
                                                Войти
                                            </button>
                                        </div>
                                    </form>
                                </div>
                            </CardBody>
                        </Card>
                    </Col>
                </Row>
            </Container>
            <Notification type={Colors.primary} message={""}/>
        </div>
    );
};

export default SignUpPage;
