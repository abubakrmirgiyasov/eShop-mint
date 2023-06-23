import React, { useEffect, useState } from "react";
import {
  Button,
  Card,
  CardBody,
  CardHeader,
  Col,
  Row,
  Spinner,
  TabPane,
} from "reactstrap";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { Error } from "../../components/Notification/Error";
import { Success } from "../../components/Notification/Success";
import { Link } from "react-router-dom";

const Address = ({ userId, next, setAddress }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(null);
  const [addresses, setAddresses] = useState([]);

  useEffect(() => {
    setIsLoading(true);
    fetchWrapper
      .get("api/user/getuseraddressesbyid/" + userId)
      .then((response) => {
        setIsLoading(false);
        setAddresses(response);
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  }, []);

  const handleNextClick = (address) => {
    setAddress(address);
    next(3);
  };

  return (
    <React.Fragment>
      {error ? <Error message={error} /> : null}
      {success ? <Success message={success} /> : null}
      <TabPane tabId={2}>
        <h3>Выберете адрес доставки</h3>
        {isLoading ? (
          <div className={"d-flex justify-content-center align-items-center"}>
            <Spinner color={"success"} size={"sm"}>
              Loading...
            </Spinner>
          </div>
        ) : (
          <Row>
            {addresses.length ? (
              addresses.map((item, key) => (
                <Col lg={4} key={key}>
                  <Card>
                    <CardHeader>
                      <Button
                        color={"success"}
                        className={"btn btn-success w-100"}
                        onClick={() => handleNextClick(item)}
                      >
                        На этот адрес
                      </Button>
                    </CardHeader>
                    <CardBody>
                      <h3 className={"fw-semibold"}>{item.fullName}</h3>
                      <div className={"d-flex justify-content-between"}>
                        <h5 className={"text-muted"}>Email:</h5>
                        <h5 className={"fw-medium"}>{item.email}</h5>
                      </div>
                      <div className={"d-flex justify-content-between"}>
                        <h5 className={"text-muted"}>Телефон:</h5>
                        <h5 className={"fw-medium"}>{item.phone}</h5>
                      </div>
                      <div className={"d-flex justify-content-between"}>
                        <h5 className={"text-muted"}>Страна:</h5>
                        <h5 className={"fw-medium"}>{item.country}</h5>
                      </div>
                      <div className={"d-flex justify-content-between"}>
                        <h5 className={"text-muted"}>Город:</h5>
                        <h5 className={"fw-medium"}>{item.city}</h5>
                      </div>
                      <div className={"d-flex justify-content-between"}>
                        <h5 className={"text-muted"}>Почтовый индекс:</h5>
                        <h5 className={"fw-medium"}>{item.zipCode}</h5>
                      </div>
                      <div className={"d-flex flex-column"}>
                        <h5 className={"text-muted"}>Описание к адресу:</h5>
                        <p className={"fw-medium"}>{item.description}</p>
                      </div>
                    </CardBody>
                  </Card>
                </Col>
              ))
            ) : (
              <Link
                to={"/profile/addresses"}
                className={"btn btn-warning mt-3"}
              >
                Добавить новый адрес
              </Link>
            )}
          </Row>
        )}
      </TabPane>
    </React.Fragment>
  );
};

export default Address;
