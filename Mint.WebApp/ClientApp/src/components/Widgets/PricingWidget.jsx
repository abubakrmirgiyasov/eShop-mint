import React from "react";
import { Col } from "reactstrap";

const PricingWidget = ({ ico, label, detail }) => {
  return (
    <React.Fragment>
      <Col lg={3} sm={6}>
        <div className={"p-2 border border-dashed rounded"}>
          <div className={"d-flex align-items-center"}>
            <div className={"avatar-sm me-2"}>
              <div
                className={
                  "avatar-title rounded bg-transparent text-success fs-24"
                }
              >
                <i className={ico}></i>
              </div>
            </div>
            <div className={"flex-grow-1"}>
              <p className={"text-muted mb-1"}>{label}</p>
              <h5 className={"mb-0"}>{detail}</h5>
            </div>
          </div>
        </div>
      </Col>
    </React.Fragment>
  );
};

export { PricingWidget };
