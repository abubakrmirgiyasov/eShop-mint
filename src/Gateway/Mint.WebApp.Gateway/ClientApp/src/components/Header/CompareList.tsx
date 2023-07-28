import React, { FC, useState } from "react";
import { Col, Dropdown, DropdownMenu, DropdownToggle, Row } from "reactstrap";
import { useDispatch } from "react-redux";
import { getCompareProducts } from "../../store/compare/compare";
import { IProduct } from "../../services/types/IProduct";
import SimpleBar from "simplebar-react";
import { Link } from "react-router-dom";

interface ICompare {
  products: IProduct[];
}

const CompareList: FC<ICompare> = ({ products }) => {
  const [isCompareDropdown, setIsLikeDropdown] = useState<boolean>(false);

  const dispatch = useDispatch();

  const toggleCompareDropdown = () => {
    setIsLikeDropdown(!isCompareDropdown);
    dispatch(getCompareProducts(!isCompareDropdown));
  };

  return (
    <React.Fragment>
      <div>
        <Dropdown
          isOpen={isCompareDropdown}
          toggle={toggleCompareDropdown}
          className={"topbar-head-dropdown ms-1 header-item"}
        >
          <DropdownToggle
            type={"button"}
            tag={"button"}
            className={
              "btn btn-icon btn-topbar btn-ghost-secondary rounded-circle"
            }
          >
            <i className={"ri-scales-line fs-22"}></i>
            <span
              className={
                "position-absolute cartitem-badge topbar-badge fs-10 translate-middle badge rounded-pill bg-danger"
              }
            >
              {products.length}
            </span>
          </DropdownToggle>
          <DropdownMenu
            className={
              "dropdown-menu-xl dropdown-menu-end p-0 dropdown-menu-cart"
            }
            aria-labelledby={"page-header-cart-dropdown"}
          >
            <div
              className={
                "p-3 border-top-0 border-start-0 border-end-0 border-dashed border"
              }
            >
              <Row className={"align-items-center"}>
                <Col>
                  <h6 className={"m-0 fs-16 fw-semibol"}>Список сравнений</h6>
                </Col>
                <Col className={"col-auto"}>
                  <span className={"badge badge-soft-primary fs-13"}>
                    <span className={"cartitem-badge"}>
                      Товаров в списке: {products.length}
                    </span>
                  </span>
                </Col>
              </Row>
            </div>
            <SimpleBar>
              <div className={"p-2"}>
                <div
                  className={`text-center empty-cart ${
                    products.length === 0 ? "d-block" : "d-none"
                  }`}
                  id={"empty-cart"}
                >
                  <div className={"avatar-md mx-auto my-3"}>
                    <div
                      className={
                        "avatar-title bg-soft-info text-info fs-36 rounded-circle"
                      }
                    >
                      <i className="ri-scales-line"></i>
                    </div>
                  </div>
                  <h5 className={"mb-3"}>Упс, тут пусто!</h5>
                  <Link
                    to={"/categories"}
                    className={"btn btn-primary w-md mb-3"}
                  >
                    К покупкам
                  </Link>
                </div>
                {products.map((product, key) => (
                  <div
                    className={
                      "d-block dropdown-item text-wrap dropdown-item-cart px-3 py-2"
                    }
                    key={key}
                  >
                    <div className={"d-flex align-items-center"}>
                      <img
                        src={product.photos ? product.photos[0] : "/"}
                        className={"me-3 rounded-circle avatar-sm p-2 bg-light"}
                        style={{ objectFit: "scale-down" }}
                        alt={product.name}
                      />
                      <div className={"flex-1"}>
                        <h6 className={"mt-0 mb-1 fs-14"}>
                          <Link
                            to={"/product-details/" + product.id}
                            color={"primary"}
                          >
                            {product.name}
                          </Link>
                        </h6>
                      </div>
                    </div>
                  </div>
                ))}
              </div>
            </SimpleBar>
          </DropdownMenu>
        </Dropdown>
      </div>
    </React.Fragment>
  );
};

export default CompareList;
