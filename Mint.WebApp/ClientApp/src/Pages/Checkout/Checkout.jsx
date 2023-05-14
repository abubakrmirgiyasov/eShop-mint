import React, { useState } from "react";
import { useSelector } from "react-redux";
import Signin from "../Auth/Signin";
import {
  Card,
  CardBody,
  Nav,
  Row,
  NavLink,
  NavItem,
  TabContent,
  TabPane,
  Button,
} from "reactstrap";
import classNames from "classnames";
import { Link } from "react-router-dom";
import Address from "./Address";
import Shipping from "./Shipping";
import Payment from "./Payment";
import Breadcrumb from "../../components/Breadcrumb/Breadcrumb";
import Confirmation from "./Confirmation";
import Finish from "./Finish";

const Checkout = () => {
  const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);
  const [activeTab, setActiveTab] = useState(2);
  const [passedSteps, setPassedSteps] = useState([1]);
  const [addressDetail, setAddressDetail] = useState(null);
  const [shippingDetail, setShippingDetail] = useState(null);
  const [paymentDetail, setPaymentDetail] = useState(null);
  const [newOrderId, setNewOrderId] = useState(null);

  const { isLoggedIn, user, cartData } = useSelector((state) => ({
    isLoggedIn: state.Signin.isLoggedIn,
    user: state.Signin.user,
    cartData: state.Cart.cart,
    s: console.log(state),
  }));

  const toggleLoginModal = () => {
    setIsLoginModalOpen(!isLoggedIn);
  };

  const toggleActiveTab = (tab) => {
    if (activeTab !== tab) {
      const steps = [...passedSteps, tab];

      if (tab >= 2 && tab <= 7) {
        setActiveTab(tab);
        setPassedSteps(steps);
      }
    }
  };

  function handleAddressDetail(item) {
    setAddressDetail(item);
  }

  function handleShippingDetail(item) {
    setShippingDetail(item);
  }

  function handlePaymentDetail(item) {
    setPaymentDetail(item);
  }

  function handleNewOrder(id) {
    setNewOrderId(id);
  }

  return (
    <React.Fragment>
      <div className={"page-content"}>
        <Breadcrumb
          title={"Оформление заказа"}
          link={"/"}
          pageTitle={"Домой"}
        />
        {isLoggedIn ? (
          <Card>
            <CardBody>
              <Row>
                <div className={"step-arrow-nav mb-4"}>
                  <Nav
                    className={"nav-pills custom-nav nav-justified"}
                    role={"tablist"}
                  >
                    <NavItem>
                      <Link
                        to={"/cart"}
                        id={"steparrow-gen-info-tab"}
                        className={
                          "nav-link " +
                          classNames({
                            active: activeTab === 1,
                            done: activeTab > 1,
                          })
                        }
                      >
                        <div
                          className={
                            "d-flex flex-column justify-content-center align-items-center"
                          }
                        >
                          <div
                            className={
                              "avatar avatar-sm img-thumbnail rounded-circle d-flex justify-content-center align-items-center"
                            }
                          >
                            <i className={"bx bx-shopping-bag fs-22"}></i>
                          </div>
                          Корзина
                        </div>
                      </Link>
                    </NavItem>
                    <NavItem>
                      <NavLink
                        href={"#"}
                        id={"steparrow-gen-info-tab"}
                        className={classNames({
                          active: activeTab === 2,
                          done: activeTab > 2,
                        })}
                      >
                        <div
                          className={
                            "d-flex flex-column justify-content-center align-items-center"
                          }
                        >
                          <div
                            className={
                              "avatar avatar-sm img-thumbnail rounded-circle d-flex justify-content-center align-items-center"
                            }
                          >
                            <i className={"ri-contacts-book-line fs-22"}></i>
                          </div>
                          Адрес
                        </div>
                      </NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink
                        href={"#"}
                        id={"steparrow-gen-info-tab"}
                        className={classNames({
                          active: activeTab === 3,
                          done: activeTab > 3,
                        })}
                      >
                        <div
                          className={
                            "d-flex flex-column justify-content-center align-items-center"
                          }
                        >
                          <div
                            className={
                              "avatar avatar-sm img-thumbnail rounded-circle d-flex justify-content-center align-items-center"
                            }
                          >
                            <i className={"ri-truck-line fs-22"}></i>
                          </div>
                          Доставка
                        </div>
                      </NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink
                        href={"#"}
                        id={"steparrow-gen-info-tab"}
                        className={classNames({
                          active: activeTab === 4,
                          done: activeTab > 4,
                        })}
                      >
                        <div
                          className={
                            "d-flex flex-column justify-content-center align-items-center"
                          }
                        >
                          <div
                            className={
                              "avatar avatar-sm img-thumbnail rounded-circle d-flex justify-content-center align-items-center"
                            }
                          >
                            <i className={"ri-bank-card-2-line fs-22"}></i>
                          </div>
                          Оплата
                        </div>
                      </NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink
                        href={"#"}
                        id={"steparrow-gen-info-tab"}
                        className={classNames({
                          active: activeTab === 5,
                          done: activeTab > 5,
                        })}
                      >
                        <div
                          className={
                            "d-flex flex-column justify-content-center align-items-center"
                          }
                        >
                          <div
                            className={
                              "avatar avatar-sm img-thumbnail rounded-circle d-flex justify-content-center align-items-center"
                            }
                          >
                            <i className={"ri-fingerprint-line fs-22"}></i>
                          </div>
                          Подтверждение
                        </div>
                      </NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink
                        href={"#"}
                        id={"steparrow-gen-info-tab"}
                        className={classNames({
                          active: activeTab === 6,
                          done: activeTab > 6,
                        })}
                      >
                        <div
                          className={
                            "d-flex flex-column justify-content-center align-items-center"
                          }
                        >
                          <div
                            className={
                              "avatar avatar-sm img-thumbnail rounded-circle d-flex justify-content-center align-items-center"
                            }
                          >
                            <i className={"ri-check-fill fs-22"}></i>
                          </div>
                          Завершение
                        </div>
                      </NavLink>
                    </NavItem>
                  </Nav>
                </div>
                <TabContent activeTab={activeTab}>
                  {cartData.length ? (
                    <>
                      <Address
                        userId={user.id}
                        next={toggleActiveTab}
                        setAddress={handleAddressDetail}
                      />
                      <Shipping
                        next={toggleActiveTab}
                        setShipping={handleShippingDetail}
                      />
                      <Payment
                        next={toggleActiveTab}
                        setPayment={handlePaymentDetail}
                      />
                      <Confirmation
                        userId={user.id}
                        next={toggleActiveTab}
                        cartData={cartData}
                        address={addressDetail}
                        shipping={shippingDetail}
                        payment={paymentDetail}
                        setNewOrder={handleNewOrder}
                      />
                      <Finish newOrder={newOrderId} />
                    </>
                  ) : (
                    <>
                      <div
                        className={
                          "d-flex flex-column justify-content-center align-items-center"
                        }
                      >
                        <lord-icon
                          src={"https://cdn.lordicon.com/slkvcfos.json"}
                          trigger={"loop"}
                          delay={"1000"}
                          colors={"primary:#121331,secondary:#08a88a"}
                          style={{ width: "250px", height: "250px" }}
                        ></lord-icon>
                        <h5 className={"text-muted"}>Упс, в корзине путо!</h5>
                        <Link to={"/"} className={"btn btn-outline-success"}>
                          Перейти к покупкам
                        </Link>
                      </div>
                    </>
                  )}
                </TabContent>
              </Row>
            </CardBody>
          </Card>
        ) : (
          <Signin isOpen={!isLoggedIn} toggle={toggleLoginModal} />
        )}
      </div>
    </React.Fragment>
  );
};

export default Checkout;
