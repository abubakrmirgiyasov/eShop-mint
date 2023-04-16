import React from "react";
import { Badge, Card, CardBody, CardHeader, Col, Container, Row } from "reactstrap";
import HomeBanner from "../../components/Sliders/HomeBanner";

const Home = () => {
  return (
    <div className="page-content">
      <Container>
        <Row>
          <Col className="mb-3" lg={12}>
            <HomeBanner />
          </Col>
          <Col lg={12}>
            <Card>
              <CardHeader>
                <Badge className="bg-success fs-14">
                  <i className="mdi mdi-circle-medium fs-14"></i>Топ товары
                </Badge>
              </CardHeader>
              <CardBody>
                <Row>
                    <Col lg={12}>
                        <Badge>test1</Badge>
                        <Badge>test2</Badge>
                        <Badge>test3</Badge>
                    </Col>
                    <Col lg={12}>
                        <Badge>test1</Badge>
                        <Badge>test2</Badge>
                        <Badge>test3</Badge>
                    </Col>
                </Row>
              </CardBody>
            </Card>
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default Home;
