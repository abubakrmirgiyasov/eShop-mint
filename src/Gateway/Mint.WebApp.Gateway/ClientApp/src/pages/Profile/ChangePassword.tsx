import React, { FC, useState } from "react";
import { IUser } from "../../services/types/IUser";
import { Button, Card, CardBody, Col, Row, Spinner, TabPane } from "reactstrap";
import CustomDivider from "../../components/Common/CustomDivider";
import { Error } from "../../components/Notifications/Error";

interface IChangePassword {
  user: IUser;
}

const ChangePassword: FC<IChangePassword> = ({ user }) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");

  return (
    <React.Fragment>
      <TabPane tabId={4}>
        {error && <Error message={error} />}
        <Card>
          <CardBody>
            <h2>Изменить пароль</h2>
            <CustomDivider />
            <form className={"form-horizontal"}>
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
                    />
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
                    />
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
                    />
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
                    ) : null}
                    <i className={"ri-edit-line"}></i> Обновить пароль
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
