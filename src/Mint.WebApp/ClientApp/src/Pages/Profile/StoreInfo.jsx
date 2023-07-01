import React, { useEffect, useState } from "react";
import { Button, Card, CardBody, CardFooter, Col, Row } from "reactstrap";
import { Link } from "react-router-dom";

const StoreInfo = ({ data, categories }) => {
  return (
    <React.Fragment>
      <Row>
        <Col sm={8} className={"w-50"}>
          <Card>
            <CardBody className={"bg-light"}>
              <div
                className={
                  "d-flex flex-column justify-content-center align-items-center"
                }
              >
                <img className={"img-fluid"} src={data?.photo} />
                <h3>{data?.name}</h3>
              </div>
              <h5 className={"text-muted fs-6"}>
                Путь: <Link to={"/stores/" + data?.url}>{data?.url}</Link>
              </h5>
              <div>
                <h5 className={"fs-12"}>
                  <span className={"text-muted"}>Страна: </span>
                  {data?.country},
                </h5>
                <h5 className={"fs-12"}>
                  <span className={"text-muted"}>Город:</span> {data?.city},
                </h5>
                <h5 className={"fs-12"}>
                  <span className={"text-muted"}>Поч. индекс: </span>
                  {data?.zipCode},
                </h5>
                <h5 className={"fs-12"}>
                  <span className={"text-muted"}>Ул. </span>
                  {data?.street}
                </h5>{" "}
              </div>
              Описание:{" "}
              <div
                dangerouslySetInnerHTML={{ __html: data?.addressDescription }}
              ></div>
            </CardBody>
            <CardFooter
              className={
                "d-flex justify-content-end align-items-center bg-light"
              }
            >
              <Button
                className={"btn btn-success me-3"}
                // onClick={() =>
                //   handleChangeAddressClick({
                //     id: item.id,
                //     fullAddress: item.fullAddress,
                //     zipCode: item.zipCode,
                //     country: item.country,
                //     city: item.city,
                //     description: item.description,
                //   })
                // }
              >
                <i className={"ri-edit-line"}></i> Изменить
              </Button>
              <Button
                className={"btn btn-danger"}
                // onClick={() => handleDeleteAddressClick({ id: item.id })}
              >
                <i className={"ri-delete-bin-7-line"}></i> Удалить
              </Button>
            </CardFooter>
          </Card>
        </Col>
      </Row>
    </React.Fragment>
  );
};

export default StoreInfo;
