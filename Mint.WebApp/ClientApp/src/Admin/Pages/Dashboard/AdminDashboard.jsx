import React from "react";
import { Card, CardBody, CardHeader, Col, Row } from "reactstrap";
import PieChart from "../../components/Charts/PieChart";
import AreaChart from "../../components/Charts/AreaChart";
import NewOrdersTable from "../../components/Tables/NewOrdersTable";
import BestSalesTable from "../../components/Tables/BestSalesTable";

const AdminDashboard = () => {
  return (
    <React.Fragment>
      <div className="page-content">
        <Row>
          <Col lg={12}>
            <Card>
              <CardHeader>
                <h2>Новые заказы</h2>
              </CardHeader>
              <CardBody>
                <NewOrdersTable />
              </CardBody>
            </Card>
          </Col>
          <Col lg={12}>
            <Card>
              <CardHeader>
                <h2>Незавершенные заказы</h2>
              </CardHeader>
              <CardBody>
                <div className="mt-xl-0 mt-5">
                    <div className="d-flex justify-content-between align-content-center">
                      <div>
                        <h3 className="text-muted text-center">Последние 7 дней</h3>
                        <PieChart
                          dataColors={'["--vz-primary", "--vz-success", "--vz-warning", "--vz-danger", "--vz-info"]'}
                        />
                      </div>
                      <div>
                        <h3 className="text-muted text-center">Последние 30 дней</h3>
                        <PieChart
                          dataColors={'["--vz-primary", "--vz-success", "--vz-warning", "--vz-danger", "--vz-info"]'}
                        />
                      </div>
                      <div>
                        <h3 className="text-muted text-center">В этом году</h3>
                        <PieChart
                          dataColors={'["--vz-primary", "--vz-success", "--vz-warning", "--vz-danger", "--vz-info"]'}
                        />
                      </div>
                    </div>
                </div>
              </CardBody>
            </Card>
          </Col>
          <Col lg={12}>
            <Card>
              <CardHeader><h2>Заказы</h2></CardHeader>
              <CardBody>
                <AreaChart 
                  dataColors={'["--vz-success", "--vz-info", "--vz-danger"]'} 
                />
              </CardBody>
            </Card>
          </Col>
          <Col lg={12}>
            <Card>
              <CardHeader>
                <h2>Лучшие продажи</h2>
              </CardHeader>
              <CardBody>
                <BestSalesTable />
              </CardBody>
            </Card>
          </Col>
        </Row>
      </div>
    </React.Fragment>
  );
};

export default AdminDashboard;
