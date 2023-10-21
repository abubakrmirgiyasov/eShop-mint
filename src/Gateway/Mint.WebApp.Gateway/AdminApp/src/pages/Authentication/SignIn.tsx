import React, {FC, useState} from "react";
import {
    Card,
    CardBody,
    Col,
    Container,
    FormFeedback,
    Row,
    Spinner,
} from "reactstrap";
import Notification from "../../components/Notifications/Notification";
import {Colors} from "../../constants/commonList";
import * as Yup from "yup";
import {useForm} from "react-hook-form";
import {yupResolver} from "@hookform/resolvers/yup";
import {ISignIn} from "../../types/Authentication/ISignIn";
import {Link} from "react-router-dom";
import ParticlesAuth from "../../components/Layouts/ParticlesAuth";
import {useDispatch} from "react-redux";
import {signInStore} from "../../stores/Authentication/authStore";
import {useAxios} from "../../hooks/useAxios";

// static files
import logo from "../../assets/images/logos/logo.png";

const SignInPage: FC = () => {
    document.title = "Добро пожаловать. Авторизуйтесь чтобы продолжить - Mint";

    const dispatch = useDispatch();
    const axios = useAxios();

    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [isPasswordShown, setIsPasswordShown] = useState<boolean>(false);

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
        resolver: yupResolver(validation),
    });

    const { user, message } = useState(state => ({
        user: state?.Auth.user.data,
        message: state?.Message.message
    }));

    const onSubmit = (values: ISignIn) => {
        setIsLoading(true);

        dispatch(signInStore(axios, values))
            .then((r) => {
                setIsLoading(false);
            })
            .catch((e) => {
                console.log(e);
                setIsLoading(false);
            });
    };

    const on = () => {
        console.log(user, message);
    }

    const handlePasswordShowClick = () => setIsPasswordShown(!isPasswordShown);

    return (
        <ParticlesAuth>
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
                                            <div className={"mb-0"}>
                                                <label className={"form-label"} htmlFor={"password"}>
                                                    Пароль
                                                </label>
                                                <div
                                                    className={
                                                        "position-relative auth-pass-inputgroup mb-0"
                                                    }
                                                >
                                                    <input
                                                        type={isPasswordShown ? "text" : "password"}
                                                        id={"password"}
                                                        className={`form-control mb-0 ${
                                                            errors.password ? "is-invalid" : ""
                                                        }`}
                                                        placeholder={"Введите пароль"}
                                                        {...register("password")}
                                                    />
                                                    <FormFeedback type={"invalid"}>
                                                        {errors.password?.message}
                                                    </FormFeedback>
                                                    <button
                                                        type={"button"}
                                                        className={
                                                            "btn btn-link position-absolute end-0 top-0 text-decoration-none text-muted"
                                                        }
                                                        onClick={handlePasswordShowClick}
                                                    >
                                                        {isPasswordShown ? (
                                                            <i className={"ri-eye-line align-middle"}></i>
                                                        ) : (
                                                            <i className={"ri-eye-off-line align-middle"}></i>
                                                        )}
                                                    </button>
                                                </div>
                                            </div>
                                            <div className={"mt-0 mb-3 text-end"}>
                                                <p className={"mb-0"}>
                                                    <Link to={"/"}>Забыли пароль?</Link>
                                                </p>
                                            </div>
                                            <div
                                                className={
                                                    "d-flex justify-content-center align-items-center"
                                                }
                                            >
                                                <button
                                                    type={"submit"}
                                                    disabled={isLoading}
                                                    className={"btn btn-success"}
                                                >
                                                    {isLoading ? (
                                                        <Spinner size={"sm"} className={"me-2"}>
                                                            Loading...
                                                        </Spinner>
                                                    ) : (
                                                        <i className={"ri-login-circle-line me-2"}></i>
                                                    )}
                                                    Войти
                                                </button>

                                                <button
                                                    type={"button"}
                                                    className={"btn btn-success"}
                                                 onClick={on}
                                                >
                                                    Ви
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
        </ParticlesAuth>
    );
};

export default SignInPage;
