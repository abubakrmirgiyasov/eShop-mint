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

const Profile = () => {
  const [activeTab, setActiveTab] = useState(1);
  const [isLoading, setIsLoading] = useState(false);

  const tabChangeToggle = (tab) => {
    if (activeTab !== tab) setActiveTab(tab);
  };

  return (
    <div className="page-content">
      <div className="container">
        <Row>
          <Col md={4}>
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
                <i className="ri-checkbox-line fs-16"></i> Создать магазин
              </ListGroupItem>
            </ListGroup>
          </Col>
          <Col md={8}>
            <TabContent activeTab={activeTab}>
              <CustomerInfo />
              <Addresses />
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
