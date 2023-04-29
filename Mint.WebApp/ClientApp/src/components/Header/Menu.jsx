import React, { useEffect, useState } from "react";
import navData from "../LayoutMenuData";
import { Link, useLocation } from "react-router-dom";
import { Collapse, Col, Row, Container, Badge } from "reactstrap";
import LogoSm from "../../assets/images/logo-sm.png";
import LogoLight from "../../assets/images/logo-light.png";
import LogoDark from "../../assets/images/logo-dark.png";

const Menu = (props) => {
  const [isMoreMenu, setIsMoreMenu] = useState(false);
  const nav = navData().props.children;
  const path = useLocation();

  let menuItems = [];
  let splitMenuItems = [];
  let menuSplitContainer = 8;

  nav.forEach(function (value, key) {
    if (value["isHeader"]) menuSplitContainer++;

    if (key >= menuSplitContainer) {
      let val = value;
      val.childItems = value.subItems;
      val.isChildItem = value.subItems ? true : false;
      delete val.subItems;
      splitMenuItems.push(val);
    } else {
      menuItems.push(value);
    }
  });

  if (splitMenuItems.length > 0) {
    menuItems.push({
      id: "more",
      label: "Ещё",
      icon: "ri-briefcase-2-line",
      link: "/#",
      stateVariables: isMoreMenu,
      subItems: splitMenuItems,
      click: function (e) {
        e.preventDefault();
        setIsMoreMenu(!isMoreMenu);
      },
    });
  }

  useEffect(() => {
    window.scrollTo({
      to: 0,
      behavior: "smooth",
    });

    const initMenu = () => {
      const pathName = process.env.PUBLIC_URL + path.pathname;

      const ul = document.getElementById("navbar-nav");
      const items = ul.getElementsByTagName("a");
      let itemsArray = [...items];
      removeActivation(itemsArray);
      let matchingMenuItem = itemsArray.find((x) => {
        return x.pathname === pathName;
      });
      if (matchingMenuItem) {
        activateParentDropDown(matchingMenuItem);
      }
    };

    initMenu();
  }, [path, props.layoutType]);

  function activateParentDropDown(item) {
    item.classList.add("active");

    let parentCollapseDiv = item.closest("collapse.menu-dropdown");

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
        const parentElementDiv =
          parentCollapseDiv.parentElement.closest(
            ".collapse"
          ).previousElementSibling;
        if (parentElementDiv)
          if (parentElementDiv.closest(".collapse"))
            parentElementDiv.closest(".collapse").classList.add("show");
        parentElementDiv.classList.add("active");
        const parentElementSibling =
          parentElementDiv.parentElement.parentElement.parentElement
            .previousElementSibling;
        if (parentElementSibling) {
          parentElementSibling.classList.add("active");
        }
      }
      return false;
    }

    return false;
  }

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

  const addEventListenerOnSmHoverMenu = () => {
    // if (
    //   document.documentElement.getAttribute("data-sidebar-size") === "sm-hover"
    // )
    //   document.documentElement.setAttribute(
    //     "data-sidebar-size",
    //     "sm-hover-active"
    //   );
    // else if (
    //   document.documentElement.getAttribute("data-sidebar-size") ===
    //   "sm-hover-active"
    // )
    //   document.documentElement.setAttribute("data-sidebar-size", "sm-hover");
    // else document.documentElement.setAttribute("data-sidebar-size", "sm-hover");
  };

  return (
    <React.Fragment>
      <div className={"app-menu navbar-menu"}>
        <div className={"navbar-brand-box"}>
          <Link to={"/"} className={"logo logo-dark"}>
            <span className={"logo-sm"}>
              <img src={LogoSm} alt={""} height={"22"} />
            </span>
            <span className={"logo-lg"}>
              <img src={LogoDark} alt={""} height={"17"} />
            </span>
          </Link>
          <Link to={"/"} className={"logo logo-light"}>
            <span className={"logo-sm"}>
              <img src={LogoSm} alt={""} height={"22"} />
            </span>
            <span className={"logo-lg"}>
              <img src={LogoLight} alt={""} height={"17"} />
            </span>
          </Link>
        </div>
        <div id={"scrollbar"}>
          <Container fluid>
            <ul className={"navbar-nav"} id={"navbar-nav"}>
              {(menuItems || []).map((item, key) => {
                return (
                  <React.Fragment key={key}>
                    {!item["isHeader"] ? (
                      item.subItems ? (
                        <li className={"nav-item"}>
                          <Link
                            to={"/#"}
                            onClick={item.click}
                            className={"nav-link menu-link position-relative"}
                            data-bs-toggle={"collapse"}
                          >
                            <i className={item.icon}></i>
                            <span>{item.label}</span>

                            {item.badgeText && item.badgeStyle ? (
                              <Badge
                                pill={true}
                                color={item.badgeStyle.toLowerCase()}
                                className={"position-absolute translate-middle"}
                                style={{
                                  display: "block",
                                  left: "90%",
                                  top: "30%",
                                }}
                              >
                                {item.badgeText}
                              </Badge>
                            ) : null}
                          </Link>
                          <Link to={"/"} className={"logo logo-light"}>
                            <span className={"logo-sm"}>
                              <img src={LogoSm} alt="" height={"22"} />
                            </span>
                            <span className={"logo-lg"}>
                              <img src={LogoLight} alt={""} height={"17"} />
                            </span>
                          </Link>
                          <Collapse
                            className={
                              item.id === "baseUi" && item.subItems.length > 13
                                ? "menu-dropdown-menu"
                                : "menu-dropdown"
                            }
                            isOpen={item.stateVariables}
                            id={"sidebarApps"}
                          >
                            {item.id === "baseUi" &&
                            item.subItems.length > 13 ? (
                              <React.Fragment>
                                <Row>
                                  {item.subItems &&
                                    (item.subItems || []).map(
                                      (subItem, key) => (
                                        <React.Fragment key={key}>
                                          {key % 2 === 0 ? (
                                            <Col lg={4}>
                                              <ul className="nav nav-sm flex-column">
                                                <li className="nav-item">
                                                  <Link
                                                    to={subItem.link}
                                                    className="nav-link"
                                                  >
                                                    {subItem.label}
                                                  </Link>
                                                </li>
                                              </ul>
                                            </Col>
                                          ) : (
                                            <Col lg={4}>
                                              <ul className="nav nav-sm flex-column">
                                                <li className="nav-item">
                                                  <Link
                                                    to={subItem.link}
                                                    className="nav-link"
                                                  >
                                                    {subItem.label}
                                                  </Link>
                                                </li>
                                              </ul>
                                            </Col>
                                          )}
                                        </React.Fragment>
                                      )
                                    )}
                                </Row>
                              </React.Fragment>
                            ) : (
                              <ul className="nav nav-sm flex-column test">
                                {item.subItems &&
                                  (item.subItems || []).map((subItem, key) => (
                                    <React.Fragment key={key}>
                                      {!subItem.isChildItem ? (
                                        <li className={"nav-item"}>
                                          <Link
                                            to={
                                              subItem.link ? subItem.link : "/#"
                                            }
                                            className={"nav-link"}
                                          >
                                            {subItem.label}
                                          </Link>
                                        </li>
                                      ) : (
                                        <li className="nav-item">
                                          <Link
                                            onClick={subItem.click}
                                            className={"nav-link"}
                                            to={"/#"}
                                            data-bs-toggle={"collapse"}
                                          >
                                            {" "}
                                            {subItem.label}
                                          </Link>
                                          <Collapse
                                            className={"menu-dropdown"}
                                            isOpen={subItem.stateVariables}
                                            id={"sidebarEcommerce"}
                                          >
                                            <ul
                                              className={
                                                "nav nav-sm flex-column"
                                              }
                                            >
                                              {/* child subItms  */}
                                              {subItem.childItems &&
                                                (subItem.childItems || []).map(
                                                  (subChildItem, key) => (
                                                    <React.Fragment key={key}>
                                                      {!subChildItem.isChildItem ? (
                                                        <li className="nav-item">
                                                          <Link
                                                            to={
                                                              subChildItem.link
                                                                ? subChildItem.link
                                                                : "/#"
                                                            }
                                                            className={
                                                              "nav-link"
                                                            }
                                                          >
                                                            {subChildItem.label}
                                                          </Link>
                                                        </li>
                                                      ) : (
                                                        <li
                                                          className={"nav-item"}
                                                        >
                                                          <Link
                                                            onClick={
                                                              subChildItem.click
                                                            }
                                                            className={
                                                              "nav-link"
                                                            }
                                                            to={"/#"}
                                                            data-bs-toggle={
                                                              "collapse"
                                                            }
                                                          >
                                                            {" "}
                                                            {subChildItem.label}
                                                          </Link>
                                                          <Collapse
                                                            className={
                                                              "menu-dropdown"
                                                            }
                                                            isOpen={
                                                              subChildItem.stateVariables
                                                            }
                                                            id={
                                                              "sidebarEcommerce"
                                                            }
                                                          >
                                                            <ul
                                                              className={
                                                                "nav nav-sm flex-column"
                                                              }
                                                            >
                                                              {/* child subItms  */}
                                                              {subChildItem.childItems &&
                                                                (
                                                                  subChildItem.childItems ||
                                                                  []
                                                                ).map(
                                                                  (
                                                                    subSubChildItem,
                                                                    key
                                                                  ) => (
                                                                    <li
                                                                      className={
                                                                        "nav-item apex"
                                                                      }
                                                                      key={key}
                                                                    >
                                                                      <Link
                                                                        to={
                                                                          subSubChildItem.link
                                                                            ? subSubChildItem.link
                                                                            : "/#"
                                                                        }
                                                                        className={
                                                                          "nav-link"
                                                                        }
                                                                      >
                                                                        {
                                                                          subSubChildItem.label
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
                            )}
                          </Collapse>
                        </li>
                      ) : (
                        <li className="nav-item">
                          <Link
                            className="nav-link menu-link position-relative"
                            to={item.link ? item.link : "/#"}
                          >
                            <i className={item.icon}></i>{" "}
                            <span>{item.label}</span>
                            {item.badgeStyle && item.badgeText ? (
                              <Badge
                                pill={true}
                                color={item.badgeStyle.toLowerCase()}
                                className={
                                  "position-absolute top-0 start-100 translate-middle"
                                }
                              >
                                {item.badgeText}
                              </Badge>
                            ) : null}
                          </Link>
                        </li>
                      )
                    ) : (
                      <li className="menu-title">
                        <span data-key="t-menu">{item.label}</span>
                      </li>
                    )}
                  </React.Fragment>
                );
              })}
            </ul>
          </Container>
        </div>
      </div>
    </React.Fragment>
  );
};

export default Menu;
