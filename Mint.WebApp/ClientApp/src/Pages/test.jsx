import React from "react";
import { Button, Card, CardBody, Container } from "reactstrap";

const PlaceHolder = () => {
  return (
    <React.Fragment>
      <div className={"main-content"}>
        <div className={"page-content"}>
          <Container>
            <Card>
              <CardBody>
                <Card className={"mb-0 w-100 h-100 bg-light"}>
                  <CardBody></CardBody>
                </Card>
              </CardBody>
            </Card>
          </Container>
        </div>
      </div>
    </React.Fragment>
  );
};

export default PlaceHolder;
