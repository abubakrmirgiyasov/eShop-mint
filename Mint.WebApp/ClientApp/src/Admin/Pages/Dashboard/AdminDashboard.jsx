import React from "react";
import { Card, CardBody, Col, Row } from "reactstrap";
import PieChart from "../../components/Charts/PieCharts/PieChart";

const AdminDashboard = () => {
  return (
    <React.Fragment>
      <div className="page-content">
        <Row>
          <Col lg={8}>
            <Card>
              <CardBody>
                <div className="mt-xl-0 mt-5">
                    <h2>
                        Заказы
                    </h2>
                    <div className="d-flex">
                        <PieChart />
                    </div>
                </div>
              </CardBody>
            </Card>
          </Col>
        </Row>
      </div>
    </React.Fragment>
  );
};

export default AdminDashboard;
