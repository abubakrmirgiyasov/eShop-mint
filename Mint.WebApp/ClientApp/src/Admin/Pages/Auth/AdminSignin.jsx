import React from "react";
import { Link } from "react-router-dom";
import { Col, Container, Row } from "reactstrap";

import logoLight from "../../../assets/images/logo-light.png";
import { useSelector } from "react-redux";

const AdminSignin = ({ children }) => {
  // const { user: isLoggedIn } = useSelector((user) => user.Signin);

  // if (isLoggedIn)
  //   <Navigate to="/admin/admin-dashboard" />

  return (
    <React.Fragment>
      <Container>
        <Row>
          <Col lg={12}>
            <div className="text-center mt-sm-5 mb-4 text-white-50">
              <div>
                <Link to="/home" className="d-inline-block auth-logo">
                  <img src={logoLight} alt="" height={20} />
                </Link>
              </div>
              <p className="mt-3 fs-15 fw-medium">
                Premium Admin & Dashboard Template
              </p>
            </div>
          </Col>
        </Row>
      </Container>
    </React.Fragment>
  );
};

export default AdminSignin;
