import React, { useState } from "react";
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

const Categories = () => {
  const [isFilterOpen, setIsFilterOpen] = useState(false);

  return (
    <div className="page-content">
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
                  onClick={() => setIsFilterOpen(!isFilterOpen)}
                >
                  <i className="ri-filter-2-line"></i>
                </Button>
                <Link to="/" className="fs-14 btn btn-success">
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
              <CategoriesTable />
            </Col>
          </Row>
        </CardBody>
      </Card>
    </div>
  );
};

export default Categories;
