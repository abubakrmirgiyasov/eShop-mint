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
import Flatpickr from "react-flatpickr";
import ProductsTable from "../../components/Tables/ProductsTable";
import Select from "react-select";

const Products = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [isFilterOpen, setIsFilterOpen] = useState(false);

  return (
    <div className="page-content">
      <Card>
        <CardHeader>
          <h2>Управление продуктами</h2>
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
              <Collapse isOpen={isFilterOpen}>
                <div className="d-flex mt-3">
                  <Input
                    type="text"
                    className="w-25 me-3"
                    placeholder="Поиск по названию"
                  />
                  <Input
                    type="text"
                    className="w-25 me-3"
                    placeholder="Поиск по артиклу"
                  />
                  <div className="col-sm-auto me-3 w-25">
                    <div className="input-group">
                      <Flatpickr
                        className="form-control dash-filter-picker"
                        options={{
                          mode: "range",
                          dateFormat: "d M, Y",
                          defaultDate: ["01 Jan 2022", "31 Jan 2022"],
                        }}
                      />
                      <div className="input-group-text bg-primary border-primary text-white">
                        <i className="ri-calendar-2-line"></i>
                      </div>
                    </div>
                  </div>
                  <Select />
                  <Button color="danger">
                    <i className="ri-search-2-line"></i>
                  </Button>
                </div>
              </Collapse>
            </Col>
            <Col lg={12}>
              <ProductsTable />
            </Col>
          </Row>
        </CardBody>
      </Card>
    </div>
  );
};

export default Products;
