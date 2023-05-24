import React, { useEffect, useState } from "react";
import { Card, CardBody, CardHeader, Col, Row, Spinner } from "reactstrap";
import PieChart from "../../components/Charts/PieChart";
import AreaChart from "../../components/Charts/AreaChart";
import NewOrdersTable from "../../components/Tables/NewOrdersTable";
import BestSalesTable from "../../components/Tables/BestSalesTable";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { fetchWrapper } from "../../../helpers/fetchWrapper";
import { Error } from "../../../components/Notification/Error";

const AdminDashboard = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [orders, setOrders] = useState([]);

  const navigate = useNavigate();

  const { user, isLoggedIn } = useSelector((state) => ({
    user: state.Signin.user,
    isLoggedIn: state.Signin.isLoggedIn,
  }));

  useEffect(() => {
    if (isLoggedIn) {
      setIsLoading(true);

      fetchWrapper
        .get("api/order/getsellerordersbyid/" + user.id)
        .then((response) => {
          setIsLoading(false);
          setOrders(response);
        })
        .catch((error) => {
          setIsLoading(false);
          setError(error);
        });
    } else {
      navigate("/");
    }
  }, []);

  return (
    <React.Fragment>
      <div className="page-content">
        {error ? <Error message={error} /> : null}
        {isLoading ? (
          <div className={"d-flex justify-content-center align-items-center"}>
          <Spinner color={"success"} size={"sm"}>
              Loading...
            </Spinner>
          </div>
        ) : (
          <Row>
            <Col lg={12}>
              <Card>
                <CardHeader>
                  <h2>Новые заказы</h2>
                </CardHeader>
                <CardBody>
                  <NewOrdersTable orders={orders} />
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
                        <h3 className="text-muted text-center">
                          Последние 7 дней
                        </h3>
                        <PieChart
                          dataColors={
                            '["--vz-primary", "--vz-success", "--vz-warning", "--vz-danger", "--vz-info"]'
                          }
                        />
                      </div>
                      <div>
                        <h3 className="text-muted text-center">
                          Последние 30 дней
                        </h3>
                        <PieChart
                          dataColors={
                            '["--vz-primary", "--vz-success", "--vz-warning", "--vz-danger", "--vz-info"]'
                          }
                        />
                      </div>
                      <div>
                        <h3 className="text-muted text-center">В этом году</h3>
                        <PieChart
                          dataColors={
                            '["--vz-primary", "--vz-success", "--vz-warning", "--vz-danger", "--vz-info"]'
                          }
                        />
                      </div>
                    </div>
                  </div>
                </CardBody>
              </Card>
            </Col>
            <Col lg={12}>
              <Card>
                <CardHeader>
                  <h2>Заказы</h2>
                </CardHeader>
                <CardBody>
                  <AreaChart
                    dataColors={'["--vz-success", "--vz-primary", "--vz-danger"]'}
                    orders={orders}
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
                  <BestSalesTable orders={orders} />
                </CardBody>
              </Card>
            </Col>
          </Row>
        )}
      </div>
    </React.Fragment>
  );
};

export default AdminDashboard;
