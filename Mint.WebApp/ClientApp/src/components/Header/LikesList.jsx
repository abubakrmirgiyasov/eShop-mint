import React, { useRef, useState } from "react";
import { Col, Dropdown, DropdownMenu, DropdownToggle, Row } from "reactstrap";

const LikesList = () => {
  const likeItemList = useRef(null);
  const [isLikeDropdown, setIsLikeDropdown] = useState(false);
  const [likeItem, setLikeItem] = useState(0);

  const toggleLikeDropdown = () => {
    setIsLikeDropdown(!isLikeDropdown);
    setLikeItem(0);
  };

  return (
    <React.Fragment>
      <Dropdown
        isOpen={isLikeDropdown}
        toggle={toggleLikeDropdown}
        className="topbar-head-dropdown ms-1 header-item"
      >
        <DropdownToggle
          type="button"
          tag="button"
          className="btn btn-icon btn-topbar btn-ghost-secondary rounded-circle"
        >
          <i className="bx bx-heart fs-22"></i>
          <span className="position-absolute cartitem-badge topbar-badge fs-10 translate-middle badge rounded-pill bg-danger">
            {0}
          </span>
        </DropdownToggle>
        <DropdownMenu
          className="dropdown-menu-xl dropdown-menu-end p-0 dropdown-menu-cart"
          aria-labelledby="page-header-cart-dropdown"
        >
          <div className="p-3 border-top-0 border-start-0 border-end-0 border-dashed border">
            <Row className="align-items-center">
              <Col>
                <h6 className="m-0 fs-16 fw-semibol">
                  Список желаний
                </h6>
              </Col>
              <Col className="col-auto">
                <span className="badge badge-soft-warning fs-13">
                  <span className="cartitem-badge">
                    Товаров в списке: {likeItem == 0 ? 0 : likeItem}
                  </span>
                </span>
              </Col>
            </Row>
          </div>
        </DropdownMenu>
      </Dropdown>
    </React.Fragment>
  );
};

export default LikesList;
