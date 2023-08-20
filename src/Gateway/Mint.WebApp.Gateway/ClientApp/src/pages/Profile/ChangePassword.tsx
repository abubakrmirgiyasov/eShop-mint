import React, { FC, useState } from "react";
import { IUser } from "../../services/types/IUser";
import {
  Button,
  Card,
  CardBody,
  Col,
  FormFeedback,
  Row,
  Spinner,
  TabPane,
} from "reactstrap";
import CustomDivider from "../../components/Common/CustomDivider";
import { Error } from "../../components/Notifications/Error";
import * as Yup from "yup";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { fetch } from "../../helpers/fetch";
import { Success } from "../../components/Notifications/Success";

interface IChangePassword {
  user: IUser;
}

interface IPassword {
  password: string;
  newPassword: string;
  confirmPassword: string;
}

const ChangePassword: FC<IChangePassword> = ({ user }) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");
  const [success, setSuccess] = useState<string>("");

  const validation = Yup.object().shape({
    currentPassword: Yup.string().required("Заполните обязательное поле"),
    newPassword: Yup.string().required("Заполните обязательное поле"),
    confirmPassword: Yup.string().required("Заполните обязательное поле"),
  });

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<IPassword>({
    resolver: yupResolver(validation),
  });

  const onSubmit = (values: IPassword) => {
    setIsLoading(true);

    fetch()
      .put("/user/updateuserpassword", values)
      .then(() => {
        setIsLoading(false);
        setSuccess("Пароль успешно обновлен");
        reset();
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  };

  return (
    <React.Fragment>
      <TabPane tabId={4}>
        {error && <Error message={error} />}
        {success && <Success message={success} />}
        <Card>
          <CardBody>
            <h2>Изменить пароль</h2>
            <CustomDivider />
            <form
              className={"form-horizontal"}
              onSubmit={handleSubmit(onSubmit)}
            >
              <Row>
                <Col lg={12} className={"mb-3"}>
                  <div className={"form-group"}>
                    <label className={"form-label"} htmlFor={"oldPassword"}>
                      Старый пароль
                    </label>
                    <input
                      type={"password"}
                      id={"oldPassword"}
                      className={"form-control"}
                      placeholder={"Введите старый пароль"}
                      defaultValue={""}
                      {...register("password")}
                    />
                    <FormFeedback type={"invalid"}>
                      {errors.password?.message}
                    </FormFeedback>
                  </div>
                </Col>
                <Col lg={12} className={"mb-3"}>
                  <div className={"form-group"}>
                    <label className={"form-label"} htmlFor={"newPassword"}>
                      Новый пароль
                    </label>
                    <input
                      type={"password"}
                      id={"newPassword"}
                      className={"form-control"}
                      placeholder={"Введите новый пароль"}
                      defaultValue={""}
                      {...register("newPassword")}
                    />
                    <FormFeedback type={"invalid"}>
                      {errors.newPassword?.message}
                    </FormFeedback>
                  </div>
                </Col>
                <Col lg={12} className={"mb-3"}>
                  <div className={"form-group"}>
                    <label className={"form-label"} htmlFor={"confirmPassword"}>
                      Повторите пароль
                    </label>
                    <input
                      type={"password"}
                      id={"confirmPassword"}
                      className={"form-control"}
                      placeholder={"Повторите новый пароль"}
                      defaultValue={""}
                      {...register("confirmPassword")}
                    />
                    <FormFeedback type={"invalid"}>
                      {errors.confirmPassword?.message}
                    </FormFeedback>
                  </div>
                </Col>
                <Col className={"d-flex justify-content-end align-items-end"}>
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
                      <i className={"ri-edit-line me-2"}></i>
                    )}
                    Обновить пароль
                  </Button>
                </Col>
              </Row>
            </form>
          </CardBody>
        </Card>
      </TabPane>
    </React.Fragment>
  );
};

export default ChangePassword;
