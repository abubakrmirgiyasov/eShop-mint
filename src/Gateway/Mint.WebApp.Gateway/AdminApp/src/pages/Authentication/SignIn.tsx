import React, {ChangeEvent, ChangeEventHandler, FC, MutableRefObject, useEffect, useRef, useState} from "react";
import {
    Card,
    CardBody,
    Col,
    Container,
    FormFeedback,
    Row,
    Spinner,
} from "reactstrap";
import * as Yup from "yup";
import {ChangeHandler, useForm} from "react-hook-form";
import {yupResolver} from "@hookform/resolvers/yup";
import {ISignIn} from "../../types/Authentication/ISignIn";
import {Link, useNavigate} from "react-router-dom";
import ParticlesAuth from "../../components/Layouts/ParticlesAuth";
import {useDispatch, useSelector} from "react-redux";
import {signInStore} from "../../stores/Authentication/authActions";
import {useAxios} from "../../hooks/useAxios";
import PhoneInput from "react-phone-input-2";

// static files
import logo from "../../assets/images/logos/logo.png";

const SignInPage: FC = () => {
    document.title = "Добро пожаловать. Авторизуйтесь чтобы продолжить - Mint";

    const dispatch = useDispatch();
    const axios = useAxios();
    const navigate = useNavigate();

    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [isPasswordShown, setIsPasswordShown] = useState<boolean>(false);
    const [type, setType] = useState<number>(0);

    const validation = Yup.object().shape({
        login: Yup.string()
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

    const { signIn } = useSelector((state) => ({
        signIn: state.Auth,
    }));

    useEffect(() => {
        if (signIn.isLoggedIn)
            navigate("/");


    }, [navigate]);

    const onLoginTypeChange = (e: ChangeEvent<HTMLSelectElement>) => {
        console.log(e)
        switch (e.currentTarget.value) {
            case 0:
                setType(0);
            case 1:
                setType(1);
            default:
                console.log("error");
        }
    };

    const onSubmit = (values: ISignIn) => {
        setIsLoading(true);

        dispatch(signInStore(axios, values))
            .then((r) => {
                navigate("/");
                setIsLoading(false);
            })
            .catch((e) => {
                setIsLoading(false);
            });
    };

    const handlePasswordShowClick = () => setIsPasswordShown(!isPasswordShown);

    return (
        <ParticlesAuth>
            <div className={"auth-page-content"}>
                <Container>
                    <Row>
                        <Col lg={12}>
                            <div className={"text-center mt-sm-5 mb-4 text-white-50"}>
                                <div>
                                    <Link to={"/"} className={"d-inline-block auth-logo"}>
                                        <img src={logo} alt={"logo mint"} height={120}/>
                                    </Link>
                                </div>
                                <p className={"mt-3 fs-15 fw-medium"}>
                                    Mint - шаблон администратора и информационной панели
                                </p>
                            </div>
                        </Col>
                    </Row>
                    <Row className={"justify-content-center"}>
                        <Col md={8} lg={6} xl={5}>
                            <Card className={"mt-4"}>
                                <CardBody className={"p-4"}>
                                    <div className={"text-center mt-2"}>
                                        <h5 className={"text-primary fs-22 fw-medium"}>Добро Пожаловать!</h5>
                                        <p>Войдите чтобы продолжить.</p>
                                    </div>
                                    <div className={"p-2 mt-4"}>
                                        <form onSubmit={handleSubmit(onSubmit)}>
                                            <Row className={"mb-3"}>
                                                <label className={"form-label"} htmlFor={"login"}>
                                                    Логин
                                                </label>
                                                <Row className={"d-flex justify-content-center"} style={{ paddingRight: 0 }}>
                                                    <Col lg={3} style={{ paddingRight: 0 }}>
                                                        <select
                                                            className={"form-select"}
                                                            onChange={onLoginTypeChange}
                                                            {...register("type")}
                                                        >
                                                            <option value={0}>Email</option>
                                                            <option value={1}>Телефон</option>
                                                        </select>
                                                    </Col>
                                                    <Col lg={9} style={{ paddingRight: 0 }}>
                                                        {type === 0 ? (
                                                            <>
                                                                <input
                                                                    type={"text"}
                                                                    id={"login"}
                                                                    className={`form-control ${
                                                                        errors.login ? "is-invalid" : ""
                                                                    }`}
                                                                    placeholder={"Введите email"}
                                                                    {...register("login")}
                                                                />
                                                                <FormFeedback type={"invalid"}>
                                                                    {errors.login?.message}
                                                                </FormFeedback>
                                                            </>
                                                        ) : (
                                                            <PhoneInput

                                                            />
                                                        )}

                                                    </Col>
                                                </Row>
                                            </Row>
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
                                                    <Link to={"/forgot-password"}>Забыли пароль?</Link>
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
                                            </div>
                                        </form>
                                    </div>
                                </CardBody>
                            </Card>
                        </Col>
                    </Row>
                </Container>
            </div>
        </ParticlesAuth>
    );
};

export default SignInPage;
