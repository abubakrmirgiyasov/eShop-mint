import React, { useEffect } from "react";
import { Link, useLocation } from "react-router-dom";
import SimpleBar from "simplebar-react";
import { Collapse, Container } from "reactstrap";
import nav from "../AdminLayoutMenuData";
import PrivateComponent from "../../helpers/privateComponent";

import LogoSm from "../../assets/images/test-logo.png";
import LogoDark from "../../assets/images/test-logo.png";
import LogoLight from "../../assets/images/test-logo.png";

const AdminSidebar = (props) => {
  const navData = nav().props.children;
  const location = useLocation();

  useEffect(() => {
    window.scrollTo({
      top: 0,
      behavior: "smooth",
    });

    const initMneu = () => {
      const pathName = process.env.PUBLIC_URL + location.pathname;
      const ul = document.getElementById("navbar-nav");
      const items = ul.getElementsByTagName("a");
      let itemsArray = [...items];

      removeActivation(itemsArray);

      let matchingMenuItem = itemsArray.find((x) => {
        return x.pathname === pathName;
      });

      if (matchingMenuItem) {
        activateParentDropdown(matchingMenuItem);
      }

      if (props.latyoutType === "vertical") {
        initMneu();
      }
    };
  }, [location.pathname, props.latyoutType]);

  const activateParentDropdown = (item) => {
    item.classList.add("active");

    let parentCollapseDiv = item.closest(".collapse.menu-dropdown");

    if (parentCollapseDiv) {
      parentCollapseDiv.classList.add("show");
      parentCollapseDiv.parentElement.children[0].classList.add("active");
      parentCollapseDiv.parentElement.children[0].setAttribute(
        "aria-expanded",
        "true"
      );

      if (parentCollapseDiv.parentElement.closest(".collapse.menu-dropdown")) {
        parentCollapseDiv.parentElement
          .closest(".collapse")
          .classList.add("show");

        if (
          parentCollapseDiv.parentElement.closest(".collapse")
            .previousElementSibling
        ) {
          parentCollapseDiv.parentElement
            .closest(".collapse")
            .previousElementSibling.classList.add("active");
        }

        if (
          parentCollapseDiv.parentElement
            .closest(".collapse")
            .previousElementSibling.closest(".collapse")
        ) {
          parentCollapseDiv.parentElement
            .closest(".collapse")
            .previousElementSibling.closest(".collapse")
            .classList.add("show");
          parentCollapseDiv.parentElement
            .closest(".collapse")
            .previousElementSibling.closest(".collapse")
            .previousElementSibling.classList.add("active");
        }
      }
      return false;
    }
    return false;
  };

  const removeActivation = (items) => {
    let activeItems = items.filter((x) => x.classList.contains("active"));

    activeItems.forEach((item) => {
      if (item.classList.contains("menu-link")) {
        if (!item.classList.contains("active")) {
          item.setAttribute("aria-expanded", false);
        }

        if (item.nextElementSibling) {
          item.nextElementSibling.classList.remove("show");
        }
      }

      if (item.classList.contains("nav-link")) {
        if (item.nextElementSibling) {
          item.nextElementSibling.classList.remove("show");
        }

        item.setAttribute("aria-expanded", false);
      }

      item.classList.remove("active");
    });
  };

  useEffect(() => {
    let verticalOverlay = document.getElementsByClassName("vertical-overlay");

    if (verticalOverlay) {
      verticalOverlay[0].addEventListener("click", function () {
        document.body.classList.remove("vertical-sidebar-enable");
      });
    }
  });

  const addEventListenerOnSmHoverMenu = () => {
    if (
      document.documentElement.getAttribute("data-sidebar-size") === "sm-hover"
    ) {
      document.documentElement.setAttribute(
        "data-sidebar-size",
        "sm-hover-active"
      );
    } else if (
      document.documentElement.getAttribute("data-sidebar-size") ===
      "sm-hover-active"
    ) {
      document.documentElement.setAttribute("data-sidebar-size", "sm-hover");
    } else {
      document.documentElement.setAttribute("data-sidebar-size", "sm-hover");
    }
  };

  return (
    <React.Fragment>
      <div className="app-menu navbar-menu">
        <div className="navbar-brand-box">
          <Link to="/admin/admin-dashboard" className="logo logo-dark">
            <span className="logo-sm">
              <img src={LogoSm} height="22" />
            </span>
            <span className="logo-lg">
              <img src={LogoDark} height="17" />
            </span>
          </Link>
          <Link to="/" className="logo logo-light">
            <span className="logo-sm">
              <img src={LogoSm} height="22" />
            </span>
            <span className="logo-lg">
              <img src={LogoLight} height="17" />
            </span>
          </Link>
          <button
            onClick={addEventListenerOnSmHoverMenu}
            type="button"
            className="btn btn-sm p-0 fs-20 header-item float-end btn-vertical-sm-hover"
            id="vertical-hover"
          >
            <i className="ri-record-circle-line"></i>
          </button>
        </div>
        <React.Fragment>
          <SimpleBar id="scrollbar" className="h-100">
            <Container fluid>
              <ul className="navbar-nav" id="navbar-nav">
                {(navData || []).map((item, key) => {
                  return (
                    <React.Fragment key={key}>
                      {item["isHeader"] ? (
                        <PrivateComponent>
                          <li className="menu-title" roles={item.roles}>
                            <span data-key="t-menu">{item.label}</span>
                          </li>
                        </PrivateComponent>
                      ) : item.subItems ? (
                        <PrivateComponent>
                          <li className="nav-item" roles={item.roles}>
                            <Link
                              onClick={item.click}
                              className="nav-link menu-link"
                              to={item.link ? item.link : "/#"}
                              data-bs-toggle="collapse"
                            >
                              <i className={item.icon}></i>
                              <span data-key="t-apps">{item.label}</span>
                              {item.badgeName ? (
                                <span
                                  className={
                                    "badge badge-pill bg-" + item.badgeColor
                                  }
                                  data-key="t-new"
                                >
                                  {item.badgeName}
                                </span>
                              ) : null}
                            </Link>
                            <Collapse
                              className="menu-dropdown"
                              isOpen={item.stateVariables}
                              id="sidebarApps"
                              roles={item.roles}
                            >
                              <ul className="nav nav-sm flex-column">
                                {item.subItems &&
                                  (item.subItems || []).map((subItem, key) => (
                                    <React.Fragment key={key}>
                                      {!subItem.isChildItem ? (
                                        <li className="nav-item">
                                          <Link
                                            to={
                                              subItem.link ? subItem.link : "/#"
                                            }
                                            className="nav-link"
                                          >
                                            {subItem.label}
                                            {subItem.badgeName ? (
                                              <span
                                                className={
                                                  "badge badge-pill bg-" +
                                                  subItem.badgeColor
                                                }
                                                data-key="t-new"
                                              >
                                                {subItem.badgeName}
                                              </span>
                                            ) : null}
                                          </Link>
                                        </li>
                                      ) : (
                                        <li className="nav-item">
                                          <Link
                                            onClick={subItem.click}
                                            className="nav-link"
                                            to="/#"
                                            data-bs-toggle="collapse"
                                          >
                                            {subItem.label}
                                            {subItem.badgeName ? (
                                              <span
                                                className={
                                                  "badge badge-pill bg-" +
                                                  subItem.badgeColor
                                                }
                                                data-key="t-new"
                                              >
                                                {subItem.badgeName}
                                              </span>
                                            ) : null}
                                          </Link>
                                          <Collapse
                                            className="menu-dropdwon"
                                            isOpen={subItem.stateVariables}
                                            id="sidebarEccomerce"
                                          >
                                            <ul className="nav nav-sm flex-column">
                                              {subItem.childItems &&
                                                (subItem.childItems || []).map(
                                                  (childItem, key) => (
                                                    <React.Fragment key={key}>
                                                      {!childItem.childItems ? (
                                                        <li className="nav-item">
                                                          <Link
                                                            to={
                                                              childItem.link
                                                                ? childItem.link
                                                                : "/#"
                                                            }
                                                            className="nav-link"
                                                          >
                                                            {childItem.label}
                                                          </Link>
                                                        </li>
                                                      ) : (
                                                        <li className="nav-item">
                                                          <Collapse
                                                            className="menu-dropdown"
                                                            isOpen={
                                                              childItem.stateVariables
                                                            }
                                                            id="sidebaremailTemplates"
                                                          >
                                                            <ul className="nav nav-sm flex-column">
                                                              {childItem.childItems.map(
                                                                (
                                                                  subChildItem,
                                                                  key
                                                                ) => (
                                                                  <li
                                                                    className="nav-item"
                                                                    key={key}
                                                                  >
                                                                    <Link
                                                                      to={
                                                                        subChildItem.link
                                                                      }
                                                                      className="nav-link"
                                                                      data-key="t-basic-action"
                                                                    >
                                                                      {
                                                                        subChildItem.label
                                                                      }
                                                                    </Link>
                                                                  </li>
                                                                )
                                                              )}
                                                            </ul>
                                                          </Collapse>
                                                        </li>
                                                      )}
                                                    </React.Fragment>
                                                  )
                                                )}
                                            </ul>
                                          </Collapse>
                                        </li>
                                      )}
                                    </React.Fragment>
                                  ))}
                              </ul>
                            </Collapse>
                          </li>
                        </PrivateComponent>
                      ) : (
                        <PrivateComponent>
                          <li className="nav-item" roles={item.roles}>
                            <Link
                              className="nav-link menu-link"
                              to={item.link ? item.link : "/#"}
                            >
                              <i className={item.icon}></i>
                              <span>{item.label}</span>
                              {item.badgeName ? (
                                <span
                                  className={
                                    "badge badge-pill bg-" + item.badgeColor
                                  }
                                  data-key="t-new"
                                >
                                  {item.badgeName}
                                </span>
                              ) : null}
                            </Link>
                          </li>
                        </PrivateComponent>
                      )}
                    </React.Fragment>
                  );
                })}
              </ul>
            </Container>
          </SimpleBar>
        </React.Fragment>
      </div>
      <div className="vertical-overlay"></div>
    </React.Fragment>
  );
};

export default AdminSidebar;
