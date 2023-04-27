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
import CategoriesTable from "../../components/Tables/CategoriesTable";
import { fetchWrapper } from "../../../helpers/fetchWrapper";
import { Error } from "../../../components/Notification/Error";

const Categories = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [isFilterOpen, setIsFilterOpen] = useState(false);
  const [error, setError] = useState(null);
  const [data, setData] = useState([]);

  useEffect((response) => {
    fetchWrapper
      .get("api/category/getcategories")
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
          <h2>Управление категориями</h2>
        </CardHeader>
        <CardBody>
          <Row>
            <Col lg={12}>
              <div className="d-flex align-items-center">
                <Button
                  className="me-2 fs-14"
                  color="primary"
                  onClick={handleFilterClick}
                >
                  <i className="ri-filter-2-line"></i>
                </Button>
                <Link
                  to="/admin/categories/add"
                  className="fs-14 btn btn-success"
                >
                  <i className="ri-add-line align-middle"></i> Добавить новое
                  ...
                </Link>
              </div>
              <Collapse isOpen={isFilterOpen} horizontal={true}>
                <div className="d-flex mt-3">
                  <Input
                    type="text"
                    className="w-25 me-3"
                    placeholder="Поиск по названию"
                  />
                  <Button color="danger">
                    <i className="ri-search-2-line"></i>
                  </Button>
                </div>
              </Collapse>
            </Col>
            <Col lg={12}>
              <CategoriesTable data={data} />
            </Col>
          </Row>
        </CardBody>
      </Card>
    </div>
  );
};

export default Categories;
