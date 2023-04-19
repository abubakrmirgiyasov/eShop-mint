import React, { useState } from "react";
import {
  Card,
  CardBody,
  CardHeader,
  Col,
  Form,
  ListGroup,
  ListGroupItem,
  Nav,
  NavItem,
  NavLink,
  Row,
  TabContent,
} from "reactstrap";
import classnames from "classnames";
import CustomerInfo from "./CustomerInfo";
import Addresses from "./Addresses";
import Orders from "./Orders";
import ChangePassword from "./ChangePassword";
import { useSelector } from "react-redux";

const Profile = () => {
  const [activeTab, setActiveTab] = useState(1);

  const { user: user } = useSelector((user) => user.Signin);

  const tabChangeToggle = (tab) => {
    if (activeTab !== tab) setActiveTab(tab);
  };

  return (
    <div className="page-content">
      <div className="container">
        <Row>
          <Col md={4}>
            <Card className="mb-3">
              <CardBody>
                <div className="d-flex justify-content-center align-items-center mb-3">
                  <img src={user.imagePath} className="rounded-circle" width={100} height={100} />
                </div>
                <div className="text-center">
                  <h3>{user.firstName} {user.secondName}</h3>
                  <h5 className="text-muted fs-14">{user.email}</h5>
                </div>
              </CardBody>
            </Card>
            <ListGroup>
              <ListGroupItem
                tag="a"
                to="#"
                className="list-group-item-action fs-18"
              >
                Мой аккаунт
              </ListGroupItem>
              <ListGroupItem
                tag="a"
                to="#"
                onClick={() => tabChangeToggle(1)}
                className={classnames(
                  { active: activeTab === 1 },
                  "list-group-item-action fs-16 cursor-pointer"
                )}
              >
                <i className="ri-user-line fs-16"></i> Личная информация
              </ListGroupItem>
              <ListGroupItem
                tag="a"
                to="#"
                onClick={() => tabChangeToggle(2)}
                className={classnames(
                  { active: activeTab === 2 },
                  "list-group-item-action fs-16 cursor-pointer"
                )}
              >
                <i className="ri-contacts-book-line fs-16"></i> Адреса
              </ListGroupItem>
              <ListGroupItem
                tag="a"
                to="#"
                onClick={() => tabChangeToggle(3)}
                className={classnames(
                  { active: activeTab === 3 },
                  "list-group-item-action fs-16 cursor-pointer"
                )}
              >
                <i className="ri-file-list-3-line fs-16"></i> Заказы
              </ListGroupItem>
              <ListGroupItem
                tag="a"
                to="#"
                onClick={() => tabChangeToggle(4)}
                className={classnames(
                  { active: activeTab === 4 },
                  "list-group-item-action fs-16 cursor-pointer"
                )}
              >
                <i className="ri-fingerprint-line fs-16"></i> Изменить пароль
              </ListGroupItem>
              <ListGroupItem
                tag="a"
                to="#"
                onClick={() => tabChangeToggle(5)}
                className={classnames(
                  { active: activeTab === 5 },
                  "list-group-item-action fs-16 cursor-pointer"
                )}
              >
                <i className="ri-shopping-bag-3-line fs-16"></i> Создать магазин
              </ListGroupItem>
            </ListGroup>
          </Col>
          <Col md={8}>
            <TabContent activeTab={activeTab}>
              <CustomerInfo userId={user.id} />
              <Addresses userId={user.id} />
              <Orders />
              <ChangePassword />
            </TabContent>
          </Col>
        </Row>
      </div>
    </div>
  );
};

export default Profile;
