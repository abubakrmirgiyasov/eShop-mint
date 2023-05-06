import React, { useEffect, useState } from "react";
import { Card, CardBody, Col, Container, Row } from "reactstrap";

const PlaceHolder = () => {
  const [brands, setBrands] = useState([1, 2, 3, 4, 5, 6]);
  const [products, setProducts] = useState(3);

  const handleResize = () => {
    const size = window.innerWidth;

    if (size < 767) {
      setBrands([1, 2, 3]);
    } else if (size < 1024) {
      setBrands([1, 2, 3, 4, 5]);
    } else if (size < 1280) {
      setBrands([1, 2, 3, 4, 5, 6]);
    }
    console.log(size);
  };

  useEffect(() => {
    window.addEventListener("resize", handleResize, false);
  }, []);

  return (
    <React.Fragment>
      <div className={"main-content"}>
        <div className={"page-content"}>
          <Container>
            <Card>
              <CardBody style={{ height: "250px" }}>
                <Card className={"mb-0 w-100 h-100 bg-light"}>
                  <CardBody></CardBody>
                </Card>
              </CardBody>
            </Card>
            <Card>
              <CardBody style={{ height: "150px" }}>
                <Row>
                  {brands.map((_, key) => (
                    <Col
                      key={key}
                      lg={4}
                      style={{
                        width: "150px",
                        height: "115px",
                        boxShadow: "0 1px 2px rgba(56, 65, 74, 0.15)",
                        borderRadius: "0.25rem",
                        marginLeft: "10px",
                      }}
                      className={"bg-light  me-4"}
                    ></Col>
                  ))}
                </Row>
              </CardBody>
            </Card>
          </Container>
        </div>
      </div>
    </React.Fragment>
  );
};

export default PlaceHolder;
