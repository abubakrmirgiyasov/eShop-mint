import React, { FC, ReactNode, useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { IAuth } from "../../services/types/IAuth";
import { useSelector } from "react-redux";
import {
  Card,
  CardBody,
  Col,
  Container,
  ListGroup,
  ListGroupItem,
  Row,
  TabContent,
} from "reactstrap";
import CustomerInfo from "./CustomerInfo";
import { Error } from "../../components/Notifications/Error";
import { ILanguage } from "../../services/types/ICommon";
import Addresses from "./Addresses";
import Orders from "./Orders";
import ChangePassword from "./ChangePassword";
import Store from "./Store";

const Profile: FC<ReactNode> = () => {
  const [activeTab, setActiveTab] = useState<number>(1);

  const params = useParams();
  const navigate = useNavigate();

  const {
    auth,
    language,
    error,
  }: { auth: IAuth; language: ILanguage; error: string } = useSelector(
    (state) => ({
      auth: state.Auth,
      language: state.Language,
      error: state.Message.message,
    })
  );

  useEffect(() => {
    console.log(auth);
    if (!auth.isLoggedIn) {
      navigate("/signin");
    }

    switch (params.wh) {
      case "info":
        setActiveTab(1);
        break;
      case "addresses":
        setActiveTab(2);
        break;
      case "orders":
        setActiveTab(3);
        break;
      case "change-password":
        setActiveTab(4);
        break;
      case "my-store":
        setActiveTab(5);
        break;
      default:
        setActiveTab(1);
        break;
    }
  }, [navigate, params, auth]);

  const tabChangeToggle = (tab) => {
    switch (tab) {
      case 1:
        navigate("/profile/info");
        break;
      case 2:
        navigate("/profile/addresses");
        break;
      case 3:
        navigate("/profile/orders");
        break;
      case 4:
        navigate("/profile/change-password");
        break;
      case 5:
        navigate("/profile/my-store");
        break;
      default:
        navigate("/profile/info");
        break;
    }
    if (activeTab !== tab) setActiveTab(tab);
  };

  document.title = "Профиль - Mint";
  return (
    <div className={"page-content"}>
      {error ? <Error message={error} /> : null}
      {auth.isLoggedIn && (
        <Container fluid={true}>
          <Row>
            <Col md={3} className={"mb-3"}>
              <Card className={"mb-3"}>
                <CardBody>
                  <div
                    className={
                      "d-flex justify-content-center align-items-center mb-3"
                    }
                  >
                    <img
                      src={auth.user?.image}
                      className={"rounded-circle"}
                      width={100}
                      height={100}
                      alt={`${auth.user?.firstName} ${auth.user?.secondName}`}
                    />
                  </div>
                  <div className={"text-center"}>
                    <h3>{`${auth.user?.firstName} ${auth.user?.secondName}`}</h3>
                    <h5 className={"text-muted fs-14"}>{auth.user?.email}</h5>
                    <h5 className={"text-muted fs-11"}>
                      {auth.user?.description}
                    </h5>
                  </div>
                </CardBody>
              </Card>
              <ListGroup className={"list-group-fill-success"}>
                <ListGroupItem
                  tag={"a"}
                  to={"#"}
                  className={"list-group-item-action fs-18 bg-light"}
                  style={{ cursor: "default" }}
                >
                  Мой аккаунт
                </ListGroupItem>
                <ListGroupItem
                  tag={"a"}
                  to={"/profile/info"}
                  onClick={() => tabChangeToggle(1)}
                  className={
                    "list-group-item-action fs-16 cursor-pointer " +
                    `${activeTab === 1 ? "active" : ""}`
                  }
                >
                  <i className={"ri-user-line fs-16"}></i> Личная информация
                </ListGroupItem>
                <ListGroupItem
                  tag={"a"}
                  to={"/profile/addresses"}
                  onClick={() => tabChangeToggle(2)}
                  className={
                    "list-group-item-action fs-16 cursor-pointer " +
                    `${activeTab === 2 ? "active" : ""}`
                  }
                >
                  <i className="ri-contacts-book-line fs-16"></i> Адреса
                </ListGroupItem>
                <ListGroupItem
                  tag={"a"}
                  to={"/profile/orders"}
                  onClick={() => tabChangeToggle(3)}
                  className={
                    "list-group-item-action fs-16 cursor-pointer " +
                    `${activeTab === 3 ? "active" : ""}`
                  }
                >
                  <i className={"ri-file-list-3-line fs-16"}></i> Заказы
                </ListGroupItem>
                <ListGroupItem
                  tag={"a"}
                  to={"/profile/change-password"}
                  onClick={() => tabChangeToggle(4)}
                  className={
                    "list-group-item-action fs-16 cursor-pointer " +
                    `${activeTab === 4 ? "active" : ""}`
                  }
                >
                  <i className={"ri-fingerprint-line fs-16"}></i> Изменить
                  пароль
                </ListGroupItem>
                <ListGroupItem
                  tag={"a"}
                  to={"/profile/create-store"}
                  onClick={() => tabChangeToggle(5)}
                  className={
                    "list-group-item-action fs-16 cursor-pointer " +
                    `${activeTab === 5 ? "active" : ""}`
                  }
                >
                  <i className={"ri-shopping-bag-3-line fs-16"}></i> Создать
                  магазин
                </ListGroupItem>
              </ListGroup>
            </Col>
            <Col md={9} className={"mb-3"}>
              <TabContent activeTab={activeTab}>
                <CustomerInfo user={auth.user} language={language} />
                <Addresses user={auth.user} activeTab={activeTab} />
                <Orders user={auth.user} activeTab={activeTab} />
                <ChangePassword user={auth.user} />
                <Store userId={auth.user.id} activeTab={activeTab} />
              </TabContent>
            </Col>
          </Row>
        </Container>
      )}
    </div>
  );
};

export default Profile;
