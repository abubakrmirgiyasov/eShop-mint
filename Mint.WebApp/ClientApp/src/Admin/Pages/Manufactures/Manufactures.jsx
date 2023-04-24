import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import {
  Button,
  Card,
  CardBody,
  CardHeader,
  Col,
  Collapse,
  Input,
  Row,
} from "reactstrap";
import PrivateComponent from "../../../helpers/privateComponent";
import { Roles } from "../../../constants/Roles";
import ManufacturesTable from "../../components/Tables/ManufacturesTable";
import { fetchWrapper } from "../../../helpers/fetchWrapper";
import { Error } from "../../../components/Notification/Error";
import DeleteManufactureModal from "./DeleteManufactureModal";

const Manufactures = () => {
  const [isFilterOpen, setIsFilterOpen] = useState(false);
  const [data, setData] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  useEffect(() => {
    setIsLoading(true);

    fetchWrapper
      .get("api/manufacture/getmanufactures")
      .then((response) => {
        setIsLoading(false);
        setData(response);
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  }, []);

  const handleFilterClick = (e) => {
    setIsFilterOpen(!isFilterOpen);
  };

  return (
    <div className="page-content">
      {error ? <Error message={error} /> : null}
      <Card>
        <CardHeader>
          <h2>Производители</h2>
        </CardHeader>
        <CardBody>
          {isLoading ? (
            <div className="d-flex justify-content-center align-items-center">
              <div className="spinner-grow text-success" role="status">
                <span className="visually-hidden">Loading...</span>
              </div>
            </div>
          ) : (
            <Row>
              <Col lg={12} className="mb-3">
                <div className="d-flex align-items-center">
                  <Button
                    className="me-2 fs-14"
                    color="primary"
                    onClick={handleFilterClick}
                  >
                    <i className="ri-filter-2-line"></i>
                  </Button>
                  <PrivateComponent>
                    <Link
                      to="/admin/manufactures/add"
                      className="fs-14 btn btn-success"
                      roles={[Roles.Admin]}
                    >
                      <i className="ri-add-line align-middle"></i> Добавить
                      новое ...
                    </Link>
                  </PrivateComponent>
                </div>
                <Collapse isOpen={isFilterOpen} horizontal={true}>
                  <div className="d-flex mt-3">
                    <Input
                      type="text"
                      className="w-25 me-2"
                      placeholder="Поиск по названию"
                    />
                    <Button color="danger">
                      <i className="ri-search-2-line"></i>
                    </Button>
                  </div>
                </Collapse>
              </Col>
              <Col lg={12}>
                <ManufacturesTable data={data} />
                <DeleteManufactureModal />
              </Col>
            </Row>
          )}
        </CardBody>
      </Card>
    </div>
  );
};

export default Manufactures;
