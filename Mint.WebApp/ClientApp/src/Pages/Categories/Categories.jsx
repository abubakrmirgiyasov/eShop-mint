import React from "react";
import { Card, CardBody, Col, Container, Row } from "reactstrap";
import { useSelector } from "react-redux";
import Breadcrumb from "../../components/Breadcrumb/Breadcrumb";
import { Link } from "react-router-dom";

const Categories = () => {
  const { menu } = useSelector((state) => ({
    menu: state.Categories.menu,
  }));

  return (
    <div className={"page-content"}>
      <Breadcrumb title={"Категории"} pageTitle={"Домой"} link={"/"} />
      <Container>
        <Card>
          <CardBody>
            <Row>
              {menu.map((item, key) => (
                <Col lg={4} key={key}>
                  <ul>
                    <li className={"fs-18"}>{item.parentName}</li>
                    {item.menuChildViewModels.map((child, childKey) => (
                      <ul key={childKey}>
                        <li>
                          <Link to={child.link}>{child.childName}</Link>
                        </li>
                      </ul>
                    ))}
                  </ul>
                </Col>
              ))}
            </Row>
          </CardBody>
        </Card>
      </Container>
    </div>
  );
};

export default Categories;
