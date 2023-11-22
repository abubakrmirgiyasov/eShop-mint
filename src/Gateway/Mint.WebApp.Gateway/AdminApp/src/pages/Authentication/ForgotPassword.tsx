import React, {FC, useState} from 'react';
import ParticlesAuth from "../../components/Layouts/ParticlesAuth";
import {Alert, Card, CardBody, Col, Container, FormFeedback, Row, Spinner} from "reactstrap";
import {Link} from "react-router-dom";
import * as Yup from "yup";
import {useForm} from "react-hook-form";
import {yupResolver} from "@hookform/resolvers/yup";

// static files
import logo from "../../assets/images/logos/logo.png";
import {ISignIn} from "../../types/Authentication/ISignIn";
import {useAxios} from "../../hooks/useAxios";
import {ADMIN_FORGET_PASSWORD_EMAIL} from "../../constants/urls";

interface IForgotPassword {
    email: string;
}

const ForgotPassword: FC = () => {
    document.title = "Сброс пароля - Mint";

    const [isLoading, setIsLoading] = useState<boolean>(false);

    const axios = useAxios();

    const validation = Yup.object().shape({
        email: Yup.string()
            .required("Заполните обязательное поле")
            .email("Введите действительный адрес электронной почты")
            .matches(/^(?!.*@[^,]*,)/),
    });

    const {
        register,
        handleSubmit,
        formState: {errors},
    } = useForm<ISignIn>({
        resolver: yupResolver(validation),
    });

    const onSubmit = (values: IForgotPassword) => {
        setIsLoading(true);

        axios.post("/pass/email/SendTestMail", values)
            .then((response) => {
                console.log(response);
                setIsLoading(false);
            })
            .catch((error) => {
                console.log(error);
                setIsLoading(false);
            });
    };

    return (
        <ParticlesAuth>
            <div className={"auth-page-content"}>
                <Container>
                    <Row>
                        <Col lg={12}>
                            <div className={"text-center mt-sm-5 mb-4 text-white-50"}>
                                <div>
                                    <Link to={"/"} className={"d-inline-block auth-logo"}>
                                        <img
                                            src={logo}
                                            alt={"logo"}
                                            height={120}
                                        />
                                    </Link>
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
                                        <h5 className={"text-primary"}>Забыли пароль?</h5>
                                        <p>Сбросить пароль с помощью Mint</p>
                                        <lord-icon
                                            src={"https://cdn.lordicon.com/rhvddzym.json"}
                                            trigger={"loop"}
                                            colors={"primary:#0ab39c"}
                                            className={"avatar-xl"}
                                            style={{ width: "120px", height: "120px" }}
                                        ></lord-icon>
                                    </div>
                                    <Alert className={"alert-borderless alert-warning text-center mb-2 mx-2"} role={"alert"}>
                                        Введите свой адрес электронной почты/телефон и инструкции будут отправлены вам!
                                    </Alert>
                                    <div className={"p-2"}>
                                        <form onSubmit={handleSubmit(onSubmit)}>
                                            <div className={"mb-4"}>
                                                <label className={"form-label"} htmlFor={"email"}>Email/Phone</label>
                                                <input
                                                    type={"text"}
                                                    className={`form-control ${
                                                        errors.email ? "is-invalid" : ""
                                                    }`}
                                                    placeholder={"Enter email/phone"}
                                                    {...register("email")}
                                                />
                                                <FormFeedback type={"invalid"}>
                                                    {errors.email?.message}
                                                </FormFeedback>
                                            </div>
                                            <div className={"text-center mt-4"}>
                                                <button
                                                    disabled={isLoading}
                                                    className={"btn btn-success w-100"}
                                                    type={"submit"}
                                                >
                                                    {isLoading ? (
                                                        <Spinner size={"sm"} className={"me-2"}>
                                                            Loading...
                                                        </Spinner>
                                                    ) : null}
                                                    Send Reset Link
                                                </button>
                                            </div>
                                        </form>
                                    </div>
                                </CardBody>
                            </Card>
                            <div className={"mt-4 text-center"}>
                                <p className={"mb-0"}>
                                    Wait, I remember my password...
                                    <Link
                                        to={"/sign-in"}
                                        className={"fw-semibold text-primary text-decoration-underline"}
                                    >
                                        Click here
                                    </Link>
                                </p>
                            </div>
                        </Col>
                    </Row>
                </Container>
            </div>
        </ParticlesAuth>
    );
};

export default ForgotPassword;