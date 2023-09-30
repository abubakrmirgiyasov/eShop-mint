import React, {
  FC,
  FormEvent,
  ReactNode,
  useEffect,
  useRef,
  useState,
} from "react";
import { Form, Input } from "reactstrap";
import { Link, useNavigate } from "react-router-dom";
import SimpleBar from "simplebar-react";

// media
import image2 from "../../assets/images/users/avatar-2.jpg";
import image3 from "../../assets/images/users/avatar-3.jpg";
import image5 from "../../assets/images/users/avatar-5.jpg";

const SearchOptions: FC<ReactNode> = () => {
  const searchRef = useRef<HTMLInputElement | null>(null);

  const navigate = useNavigate();

  useEffect(() => {
    const searchOptions = document.getElementById("search-close-options");
    const dropdown = document.getElementById("search-dropdown");
    const searchInput = document.getElementById(
      "search-options"
    ) as HTMLInputElement;

    searchInput.addEventListener("focus", function () {
      const inputLength = searchInput.value.length;

      if (inputLength > 3) {
        dropdown.classList.add("show");
        searchOptions.classList.remove("d-none");
      } else {
        dropdown.classList.remove("show");
        searchOptions.classList.add("d-none");
      }
    });

    console.log(searchRef.current?.value);

    searchInput.addEventListener("keyup", function () {
      const inputLength = searchInput.value.length;

      if (inputLength > 3) {
        dropdown.classList.add("show");
        searchOptions.classList.remove("d-none");
      } else {
        dropdown.classList.remove("show");
        searchOptions.classList.add("d-none");
      }
    });

    searchOptions.addEventListener("click", function () {
      searchInput.value = "";
      dropdown.classList.remove("show");
      searchOptions.classList.add("d-none");
    });

    document.body.addEventListener("click", function (e) {
      if (e.currentTarget.getAttribute("id") !== "search-options") {
        dropdown.classList.remove("show");
        searchOptions.classList.add("d-none");
      }
    });
  }, []);

  const handleSearch = (e) => {
    e.preventDefault();
    navigate("/search/query=" + searchRef?.current?.value);
  };

  return (
    <React.Fragment>
      <Form className={"app-search d-none d-md-block"} onSubmit={handleSearch}>
        <div className={"position-relative"}>
          <input
            className={"form-control"}
            type={"text"}
            id={"search-options"}
            placeholder={"Поиск..."}
            ref={searchRef}
          />
          <span className={"ri-search-2-line search-widget-icon"}></span>
          <span
            className={
              "ri-close-circle-line search-widget-icon search-widget-icon-close d-none"
            }
            id={"search-close-options"}
          ></span>
        </div>
        <div
          className={"dropdown-menu dropdown-menu-lg"}
          id={"search-dropdown"}
        >
          <SimpleBar style={{ height: "320px" }}>
            <div className={"dropdown-header d-flex justify-content-between"}>
              <h6 className={"text-overflow text-muted mb-0"}>
                История поиска
              </h6>
              <h6 className={"text-overflow text-muted mb-0 cursor-pointer"}>
                Очистить историю
              </h6>
            </div>

            <Link to={"/"} className={"dropdown-item notify-item"}>
              <i className={"ri-history-line"}></i> Видеокарта
            </Link>
            <Link to={"/"} className={"dropdown-item notify-item"}>
              <i className={"ri-history-line"}></i> buttons
            </Link>

            <div className={"dropdown-header mt-2"}>
              <h6 className={"text-overflow text-muted mb-1"}>Страницы</h6>
            </div>

            <Link to={"#"} className={"dropdown-item notify-item"}>
              <i
                className={
                  "ri-bubble-chart-line align-middle fs-18 text-muted me-2"
                }
              ></i>
              <span>Analytics Dashboard</span>
            </Link>

            <Link to={"#"} className={"dropdown-item notify-item"}>
              <i
                className={
                  "ri-lifebuoy-line align-middle fs-18 text-muted me-2"
                }
              ></i>
              <span>Help Center</span>
            </Link>

            <Link to={"#"} className={"dropdown-item notify-item"}>
              <i
                className={
                  "ri-user-settings-line align-middle fs-18 text-muted me-2"
                }
              ></i>
              <span>My account settings</span>
            </Link>

            <div className={"dropdown-header mt-2"}>
              <h6 className={"text-overflow text-muted mb-2"}>Продавцы</h6>
            </div>

            <div className={"notification-list"}>
              <Link to={"#"} className={"dropdown-item notify-item py-2"}>
                <div className={"d-flex"}>
                  <img
                    src={image2}
                    className={"me-3 rounded-circle avatar-xs"}
                    alt={"user-pic"}
                  />
                  <div className={"flex-1"}>
                    <h6 className={"m-0"}>Angela Bernier</h6>
                    <span className={"fs-11 mb-0 text-muted"}>Manager</span>
                  </div>
                </div>
              </Link>

              <Link to={"#"} className={"dropdown-item notify-item py-2"}>
                <div className={"d-flex"}>
                  <img
                    src={image3}
                    className={"me-3 rounded-circle avatar-xs"}
                    alt={"user-pic"}
                  />
                  <div className={"flex-1"}>
                    <h6 className={"m-0"}>David Grasso</h6>
                    <span className={"fs-11 mb-0 text-muted"}>
                      Web Designer
                    </span>
                  </div>
                </div>
              </Link>

              <Link to={"#"} className={"dropdown-item notify-item py-2"}>
                <div className={"d-flex"}>
                  <img
                    src={image5}
                    className={"me-3 rounded-circle avatar-xs"}
                    alt={"user-pic"}
                  />
                  <div className={"flex-1"}>
                    <h6 className={"m-0"}>Mike Bunch</h6>
                    <span className={"fs-11 mb-0 text-muted"}>
                      React Developer
                    </span>
                  </div>
                </div>
              </Link>
            </div>
          </SimpleBar>

          <div className={"text-center pt-3 pb-1"}>
            <Link
              to={"/pages-search-results"}
              className={"btn btn-primary btn-sm"}
            >
              Показать результат <i className={"ri-arrow-right-line ms-1"}></i>
            </Link>
          </div>
        </div>
      </Form>
    </React.Fragment>
  );
};

export default SearchOptions;
