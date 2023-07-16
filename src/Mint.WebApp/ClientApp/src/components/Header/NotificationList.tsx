import React, { FC, ReactNode, useState } from "react";
import {
  Col,
  Dropdown,
  DropdownMenu,
  DropdownToggle,
  Nav,
  NavItem,
  NavLink,
  Row,
  TabContent,
  TabPane,
} from "reactstrap";
import SimpleBar from "simplebar-react";
import { Link } from "react-router-dom";

const NotificationList: FC<ReactNode> = () => {
  const [isNotifyDropdown, setIsNotifyDropdown] = useState<boolean>(false);
  const [activeTab, setActiveTab] = useState<number>(1);

  const toggleNotifyDropdown = () => {
    setIsNotifyDropdown(!isNotifyDropdown);
  };

  const toggleNotifyTab = (value: number) => {
    setActiveTab(value);
  };

  return (
    <React.Fragment>
      <Dropdown
        isOpen={isNotifyDropdown}
        toggle={toggleNotifyDropdown}
        className={"topbar-head-dropdown ms-1 header-item"}
      >
        <DropdownToggle
          type={"button"}
          tag={"button"}
          className={
            "btn btn-icon btn-topbar btn-ghost-secondary rounded-circle"
          }
        >
          <i className={"ri-notification-4-line fs-22"}></i>
          <span
            className={
              "position-absolute topbar-badge fs-10 translate-middle badge rounded-pill bg-danger"
            }
          >
            1 <span className="visually-hidden">непрочитанных сообщения</span>
          </span>
        </DropdownToggle>
        <DropdownMenu className={"dropdown-menu-lg dropdown-menu-end p-0"}>
          <div className={"dropdown-head bg-primary bg-pattern rounded-top"}>
            <div className={"p-3"}>
              <Row className={"align-items-center"}>
                <Col>
                  <h6 className={"text-light m-0 fs-16 fw-semibol"}>
                    Уведомления
                  </h6>
                </Col>
                <Col className={"col-auto dropdown-tabs"}>
                  <span className={"badge badge-soft-light fs-13"}>
                    1 новых
                  </span>
                </Col>
              </Row>
            </div>
          </div>
          <div className={"px-2 pt-2"}>
            <Nav className={"nav-tabs dropdown-tabs nav-tabs-custom"}>
              <NavItem>
                <NavLink
                  href={"#"}
                  className={activeTab === 1 ? "active" : ""}
                  onClick={() => toggleNotifyTab(1)}
                >
                  Все (0)
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink
                  href={"#"}
                  className={activeTab === 2 ? "active" : ""}
                  onClick={() => toggleNotifyTab(2)}
                >
                  Сообщения
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink
                  href={"#"}
                  className={activeTab === 3 ? "active" : ""}
                  onClick={() => toggleNotifyTab(3)}
                >
                  Оповещения
                </NavLink>
              </NavItem>
            </Nav>
          </div>
          <TabContent activeTab={activeTab}>
            <TabPane tabId={1} className={"py-2 ps-2"}>
              <SimpleBar style={{ maxHeight: "300px" }} className={"pe-2"}>
                <div
                  className={
                    "text-reset notification-item d-block dropdown-item position-relative"
                  }
                >
                  <div className={"d-flex"}>
                    <div className={"avatar-xs me-3"}>
                      <span
                        className={
                          "avatar-title bg-soft-info text-info rounded-circle fs-16"
                        }
                      >
                        <i className={"ri-ticket-2-line"}></i>
                      </span>
                    </div>
                    <div className="flex-1">
                      <Link to="#" className="stretched-link">
                        <h6 className="mt-0 mb-2 lh-base">
                          Your <b>Elite</b> author Graphic Optimization{" "}
                          <span className="text-secondary">reward</span> is
                          ready!
                        </h6>
                      </Link>
                      <p
                        className={
                          "mb-0 fs-11 fw-medium text-uppercase text-muted"
                        }
                      >
                        <span>
                          <i className={"mdi mdi-clock-outline"}></i> Just 30
                          sec ago
                        </span>
                      </p>
                    </div>
                    <div className={"px-2 fs-15"}>
                      <div className={"form-check notification-check"}>
                        <input
                          className={"form-check-input"}
                          type={"checkbox"}
                          defaultChecked={false}
                          id={"all-notification-check01"}
                        />
                        <label
                          className={"form-check-label"}
                          htmlFor={"all-notification-check01"}
                        ></label>
                      </div>
                    </div>
                  </div>
                </div>
              </SimpleBar>
            </TabPane>
          </TabContent>
        </DropdownMenu>
      </Dropdown>
    </React.Fragment>
  );
};

export default NotificationList;
