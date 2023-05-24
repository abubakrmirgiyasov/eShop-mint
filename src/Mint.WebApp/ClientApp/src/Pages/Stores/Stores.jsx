import React, { useEffect, useState } from "react";
import { Card, CardBody, Col, Container, Row } from "reactstrap";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { Error } from "../../components/Notification/Error";
import { Link } from "react-router-dom";

const Stores = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [stores, setStores] = useState([]);

  useEffect(() => {
    setIsLoading(true);
    fetchWrapper
      .get("api/store/getstores")
      .then((response) => {
        setIsLoading(false);
        setStores(response);
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  }, []);

  document.title = "Все магазины - Mint";
  return (
    <div className={"page-content"}>
      <Container>
        {error ? <Error message={error} /> : null}
        <Card color={"light"}>
          <CardBody>
            <h2 className={"mb-3"}>Все магазины</h2>
            {isLoading ? (
              "Loading..."
            ) : (
              <Row>
                {stores.map((item, key) => (
                  <Col key={key} lg={4}>
                    <Card
                      className={
                        "d-flex justify-content-between align-items-center mb-0"
                      }
                    >
                      <CardBody
                        className={"d-flex flex-column align-items-center"}
                      >
                        <div className={"mb-3"} style={{ height: "100px" }}>
                          <Link to={item.url}>
                            <img
                              src={item.photo}
                              className={"fluid"}
                              height={100}
                              alt={item.name}
                            />
                          </Link>
                        </div>
                        <div className={"fs-16"}>
                          <Link to={item.url}>{item.name}</Link>
                        </div>
                      </CardBody>
                    </Card>
                  </Col>
                ))}
              </Row>
            )}
          </CardBody>
        </Card>
      </Container>
    </div>
  );
};

export default Stores;
