import React from "react";
import { Link } from "react-router-dom";
import {
  Button,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Col,
  Row,
  TabPane,
} from "reactstrap";

const Addresses = () => {
  return (
    <React.Fragment>
      <TabPane tabId={2}>
        <Card>
          <CardBody>
            <Row>
              <Col md={8} lg={9}>
                <div className="d-flex justify-content-start align-items-center mb-3">
                  <h2>Адреса</h2>
                </div>
                <div className="d-flex justify-content-start align-items-center mb-3">
                  <Button className="btn btn-primary" color="primary">
                    <i className="ri-add-line"></i> Добавить новый
                  </Button>
                </div>
                <Row>
                  <Col sm={8}>
                    <Card>
                      <CardBody>
                        <h3>Johnn Smith</h3>
                        <h5 className="text-muted fs-6">
                          Email: admin@myshop.com
                          <br />
                          Phone number: 12345678
                        </h5>
                        <h5 className="text-muted fs-6">John Smith</h5>
                        <h5 className="text-muted fs-6">John Smith LLC</h5>
                        <h5 className="text-muted fs-6">1234 Main Road</h5>
                        <h5 className="text-muted fs-6">New York, AA 12212</h5>
                        <h5 className="text-muted fs-6">UNITED STATES</h5>
                      </CardBody>
                      <CardFooter className="d-flex justify-content-end align-items-center">
                        <Button className="btn btn-success me-3">
                          <i className="ri-edit-line"></i> Изменить
                        </Button>
                        <Button className="btn btn-danger">
                          <i className="ri-delete-bin-7-line"></i> Удалить
                        </Button>
                      </CardFooter>
                    </Card>
                  </Col>
                </Row>
              </Col>
            </Row>
          </CardBody>
        </Card>
      </TabPane>
    </React.Fragment>
  );
};

export default Addresses;
