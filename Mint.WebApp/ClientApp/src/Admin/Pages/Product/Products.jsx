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
import Flatpickr from "react-flatpickr";
import ProductsTable from "../../components/Tables/ProductsTable";
import Select from "react-select";
import { fetchWrapper } from "../../../helpers/fetchWrapper";
import { useSelector } from "react-redux";
import PrivateComponent from "../../../helpers/privateComponent";
import { Roles } from "../../../constants/Roles";
import { Error } from "../../../components/Notification/Error";

const Products = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [isFilterOpen, setIsFilterOpen] = useState(false);
  const [data, setIsData] = useState(null);

  const { user } = useSelector((state) => ({
    user: state.Signin.user,
  }));

  useEffect(() => {
    setIsLoading(true);
    fetchWrapper
      .get("api/product/getsellerproductsbyid/" + user.id)
      .then((response) => {
        setIsLoading(false);
        setIsData(response);
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  }, []);

  return (
      <div className={"page-content"}>
          {error ? <Error message={error} /> : null}
      <Card>
        <CardHeader>
          <h2>Управление продуктами</h2>
        </CardHeader>
        <CardBody>
          {isLoading ? (
            <div className={"d-flex justify-content-center"}>
              <div className={"spinner-border text-success"} role={"status"}>
                <span className={"sr-only"}>Loading...</span>
              </div>
            </div>
          ) : (
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
                  <PrivateComponent>
                    <Link
                      to="/admin/products/add"
                      className="fs-14 btn btn-success"
                      roles={[Roles.Admin, Roles.Seller]}
                    >
                      <i className="ri-add-line align-middle"></i> Добавить
                      новое ...
                    </Link>
                  </PrivateComponent>
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
                    <Select className={"me-3"} />
                    <Button color="danger">
                      <i className="ri-search-2-line"></i>
                    </Button>
                  </div>
                </Collapse>
              </Col>
              <Col lg={12}>
                <ProductsTable data={data} />
              </Col>
            </Row>
          )}
        </CardBody>
      </Card>
    </div>
  );
};

export default Products;
