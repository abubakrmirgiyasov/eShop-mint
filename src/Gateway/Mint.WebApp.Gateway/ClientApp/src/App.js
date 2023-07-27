import React, { Component } from 'react';
import Test from "./components/test"

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <div>Test: {<Test />}</div>
    );
  }
}
