import React, { FC, ReactNode, useEffect } from "react";
import { Link, useLocation } from "react-router-dom";
import AdminSidebarData, { ISidebar } from "../SidebarData";
import { Collapse, Container } from "reactstrap";
import SimpleBar from "simplebar-react";

// media
import LogoSm from "../../assets/images/logos/Logo.png";
import LogoLg from "../../assets/images/logos/logo-light.png";

const AdminSidebar: FC<ReactNode> = () => {
  const location = useLocation();
  const menu: ISidebar[] = AdminSidebarData();

  useEffect(() => {
    // window.scrollTo({ top: 0, behavior: "smooth" });

    initMenu();
  });

  const initMenu = () => {
    const pathName: string = location.pathname;
    const ul: HTMLElement | null = document.getElementById("navbar-nav");
    const items: HTMLCollectionOf<HTMLAnchorElement> = ul?.getElementsByTagName(
      "a"
    ) as HTMLCollectionOf<HTMLAnchorElement>;
    const itemsArray: HTMLAnchorElement[] = Array.from(items);

    removeActivation(itemsArray);

    const matchMenuItem: HTMLAnchorElement | undefined = itemsArray.find(
      (x: HTMLAnchorElement) => {
        return x.pathname === pathName;
      }
    );

    if (matchMenuItem) activateParentDropdown(matchMenuItem);

    console.log("test init");
  };

  const activateParentDropdown = (item: HTMLAnchorElement): void => {
    item.classList.add("active");

    let parentCollapseDiv: HTMLElement | null = item.closest(
      ".collapse.menu-dropdown"
    );

    if (parentCollapseDiv) {
      // to set aria expand true remaining
      parentCollapseDiv.classList.add("show");
      const parentSibling: Element | null =
        parentCollapseDiv.parentElement?.children[0];

      if (parentSibling) {
        parentSibling.classList.add("active");
        parentSibling.setAttribute("aria-expanded", "true");

        const parentCollapse: HTMLElement | null =
          parentCollapseDiv.parentElement?.closest(".collapse.menu-dropdown");

        if (parentCollapse) {
          parentCollapse.classList.add("show");
          const prevSibling: Element | null =
            parentCollapse.previousElementSibling;

          if (prevSibling) {
            prevSibling.classList.add("active");

            const prevParentCollapse: HTMLElement | null = prevSibling.closest(
              ".collapse.menu-dropdown"
            );

            if (prevParentCollapse) {
              prevParentCollapse.classList.add("show");
              const prevPrevSibling: Element | null =
                prevParentCollapse.previousElementSibling;

              if (prevPrevSibling) {
                prevPrevSibling.classList.add("active");
              }
            }
          }
        }
      }
    }
  };

  const removeActivation = (items: HTMLAnchorElement[]) => {
    let activeItems = items.filter((x) => x.classList.contains("active"));

    activeItems.forEach((item) => {
      if (item.classList.contains("menu-link")) {
        if (!item.classList.contains("active")) {
          item.setAttribute("aria-expanded", "false");
        }
        if (item.nextElementSibling) {
          item.nextElementSibling.classList.remove("show");
        }
      }
      if (item.classList.contains("nav-link")) {
        if (item.nextElementSibling) {
          item.nextElementSibling.classList.remove("show");
        }
        item.setAttribute("aria-expanded", "false");
      }
      item.classList.remove("active");
    });
  };

  return (
    <React.Fragment>
      <div className={"app-menu navbar-menu"}>
        <div className={"navbar-brand-box"}>
          <Link to={"/"} className={"logo logo-dark"}>
            <span className={"logo-sm"}>
              <img src={LogoSm} alt={"logo"} height={22} />
            </span>
            <span className={"logo-lg"}>
              <img src={LogoLg} alt={"logo"} width={107} height={29} />
            </span>
          </Link>
          <Link to={"/"} className={"logo logo-light"}>
            <span className={"logo-sm"}>
              <img src={LogoSm} alt={"logo"} height={22} />
            </span>
            <span className={"logo-lg"}>
              <img src={LogoLg} alt={"logo"} width={107} height={29} />
            </span>
          </Link>
        </div>

        <SimpleBar id={"scrollbar"} className={"h-100"}>
          <Container fluid={true}>
            <ul className={"navbar-nav"} id={"navbar-nav"}>
              {menu.map((item, key) => {
                return (
                  <React.Fragment key={key}>
                    {item.isHeader ? (
                      <li className={"menu-title"}>
                        <span data-key={"t-menu"}>{item.label}</span>
                      </li>
                    ) : item.subItems ? (
                      <li className={"nav-item"}>
                        <Link
                          onClick={item.click}
                          className={"nav-link menu-link"}
                          to={item.link}
                          data-bs-toggle={"collapse"}
                        >
                          <i className={item.icon}></i>{" "}
                          <span data-key={"t-apps"}>{item.label}</span>
                        </Link>
                        <Collapse
                          className={"menu-dropdown"}
                          isOpen={item.state}
                          id={"sidebarApps"}
                        >
                          <ul className={"nav nav-sm flex-column test"}>
                            {item.subItems &&
                              (item.subItems || []).map((subItem, key) => (
                                <li className={"nav-item"} key={key}>
                                  <Link
                                    to={subItem.link}
                                    className={"nav-link"}
                                  >
                                    {subItem.label}
                                  </Link>
                                </li>
                              ))}
                          </ul>
                        </Collapse>
                      </li>
                    ) : (
                      <li className={"nav-item"}>
                        <Link className="nav-link menu-link" to={item.link}>
                          <i className={item.icon}></i>{" "}
                          <span>{item.label}</span>
                        </Link>
                      </li>
                    )}
                  </React.Fragment>
                );
              })}
            </ul>
          </Container>
        </SimpleBar>
      </div>
      <div className="vertical-overlay"></div>
    </React.Fragment>
  );
};

export default AdminSidebar;
