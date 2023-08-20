import React, { FC } from "react";
import { Col, Row } from "reactstrap";
import { Link } from "react-router-dom";

interface IBreadCrumb {
  currentPage: string;
  linkToPage: string;
  pageTitle: string;
}

const BreadCrumb: FC<IBreadCrumb> = ({
  currentPage,
  pageTitle,
  linkToPage,
}) => {
  return (
    <React.Fragment>
      <Row>
        <Col xs={12}>
          <div
            className={
              "page-title-box d-sm-flex align-items-center justify-content-between"
            }
          >
            <h4 className={"mb-sm-0"}>{currentPage}</h4>
            <div className={"page-title-right"}>
              <ol className={"breadcrumb m-0"}>
                <li className={"breadcrumb-item"}>
                  <Link to={linkToPage}>{pageTitle}</Link>
                </li>
                <li className={"breadcrumb-item active"}>{currentPage}</li>
              </ol>
            </div>
          </div>
        </Col>
      </Row>
    </React.Fragment>
  );
};

export default BreadCrumb;
