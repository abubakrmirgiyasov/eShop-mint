import React, { useEffect, useState } from "react";
import {
  Card,
  CardBody,
  Col,
  ListGroup,
  ListGroupItem,
  Row,
  TabContent,
} from "reactstrap";
import classnames from "classnames";
import CustomerInfo from "./CustomerInfo";
import Addresses from "./Addresses";
import Orders from "./Orders";
import ChangePassword from "./ChangePassword";
import { useSelector } from "react-redux";
import Store from "./Store";
import { useNavigate, useParams } from "react-router-dom";

const Profile = () => {
  const [activeTab, setActiveTab] = useState(1);

  const params = useParams();
  const navigate = useNavigate();

  const { user, isLoggedIn } = useSelector((u) => ({
    user: u.Signin.user,
    isLoggedIn: u.Signin.isLoggedIn,
  }));

  if (!isLoggedIn) {
    navigate("/signin");
  }

  useEffect(() => {
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
      case "create-store":
        setActiveTab(5);
        break;
      default:
        setActiveTab(1);
        break;
    }
  }, [params]);

  const tabChangeToggle = (tab) => {
    if (activeTab !== tab) setActiveTab(tab);
  };

  document.title = "Профиль - Mint";
  return (
    <div className={"page-content"}>
      <div className={"container"}>
        <Row>
          <Col md={4}>
            <Card className={"mb-3"}>
              <CardBody>
                <div
                  className={
                    "d-flex justify-content-center align-items-center mb-3"
                  }
                >
                  <img
                    src={user.imagePath}
                    className={"rounded-circle"}
                    width={100}
                    height={100}
                    alt={user.firstName + " " + user.secondName}
                  />
                </div>
                <div className={"text-center"}>
                  <h3>
                    {user.firstName} {user.secondName}
                  </h3>
                  <h5 className={"text-muted fs-14"}>{user.email}</h5>
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
                className={classnames(
                  { active: activeTab === 1 },
                  "list-group-item-action fs-16 cursor-pointer"
                )}
              >
                <i className={"ri-user-line fs-16"}></i> Личная информация
              </ListGroupItem>
              <ListGroupItem
                tag="a"
                to="/profile/addresses"
                onClick={() => tabChangeToggle(2)}
                className={classnames(
                  { active: activeTab === 2 },
                  "list-group-item-action fs-16 cursor-pointer"
                )}
              >
                <i className="ri-contacts-book-line fs-16"></i> Адреса
              </ListGroupItem>
              <ListGroupItem
                tag={"a"}
                to={"/profile/orders"}
                onClick={() => tabChangeToggle(3)}
                className={classnames(
                  { active: activeTab === 3 },
                  "list-group-item-action fs-16 cursor-pointer"
                )}
              >
                <i className={"ri-file-list-3-line fs-16"}></i> Заказы
              </ListGroupItem>
              <ListGroupItem
                tag={"a"}
                to={"/profile/change-password"}
                onClick={() => tabChangeToggle(4)}
                className={classnames(
                  { active: activeTab === 4 },
                  "list-group-item-action fs-16 cursor-pointer"
                )}
              >
                <i className={"ri-fingerprint-line fs-16"}></i> Изменить пароль
              </ListGroupItem>
              <ListGroupItem
                tag={"a"}
                to={"/profile/create-store"}
                onClick={() => tabChangeToggle(5)}
                className={classnames(
                  { active: activeTab === 5 },
                  "list-group-item-action fs-16 cursor-pointer"
                )}
              >
                <i className={"ri-shopping-bag-3-line fs-16"}></i> Создать
                магазин
              </ListGroupItem>
            </ListGroup>
          </Col>
          <Col md={8}>
            <TabContent activeTab={activeTab}>
              <CustomerInfo userId={user.id} userImage={user.imagePath} />
              <Addresses activeTab={activeTab} userId={user.id} />
              <Orders userId={user.id} activeTab={activeTab} />
              <ChangePassword userId={user.id} />
              <Store userId={user.id} />
            </TabContent>
          </Col>
        </Row>
      </div>
    </div>
  );
};

export default Profile;
